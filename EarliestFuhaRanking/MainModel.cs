﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Common;
using CoreTweet;
using EarliestFuhaRanking.Configurations;
using EarliestFuhaRanking.Configurations.Macros;

namespace EarliestFuhaRanking
{
    public class MainModel
    {
        private readonly ConfigRoot config;
        private readonly List<Tweet> collectedTweets;
        private readonly Encoding reportFileEncoidng;

        /// <summary>
        /// <see cref="MainModel"/> の新しいインスタンスを生成します。
        /// </summary>
        public MainModel() 
        {
            config = ConfigManager.GetDefaultConfigRoot();
            collectedTweets = new List<Tweet>();
            reportFileEncoidng = Encoding.GetEncoding(config.FuhaReports.EncodingName);
        }

        public void CollectTweets()
        {
            Tokens token = CreateTokens(config.KeysAndTokens);
            long? maxId = null;
            DateTime today = DateTime.Today;

            collectedTweets.Clear();

            for (int i = 0; i < config.RankingCollection.MaxQueryIterationCount; ++i)
            {
                try
                {
                    // ホームタイムラインからツイートを取得
                    // max_idに指定したツイートは直前のループで処理しているので除外(2ループ目以降)
                    // 今日ツイートされたものだけ取得
                    var todayStatuses = token.Statuses
                        .HomeTimeline(count => config.RankingCollection.CountPerQuery,
                                      exclude_replies => true,
                                      max_id => maxId)
                        .Skip(maxId == null ? 0 : 1)
                        .Where(s => s.CreatedAt.LocalDateTime.Date == today);

                    if (!todayStatuses.Any()) { break; }

                    // さらにフハツイだけ取得
                    var regex = new Regex(config.RankingCollection.SearchWord);
                    var fuhaStatuses = todayStatuses.Where(s => regex.IsMatch(s.Text));
                    collectedTweets.AddRange(fuhaStatuses.Select(s => new Tweet(s)));

                    maxId = todayStatuses.LastOrDefault()?.Id;
                }
                catch (TwitterException ex)
                {
                    // 回数制限などでエラーの場合は問い合わせを中断するが、後続の処理は続行する
                    ConsoleApplication.WriteError(ex);
                    Environment.ExitCode = ConsoleException.DefaultExitCode;
                    break;
                }
            }

            collectedTweets.Reverse();
        }

        public void ReportTweets()
        {
            ReportDetailReport();
            ReportTweetReport();
        }

        /// <summary>
        /// 指定したキーとトークンで Twitter API のトークンを作成します。
        /// </summary>
        /// <param name="keysAndTokens"></param>
        /// <returns></returns>
        private Tokens CreateTokens(KeysAndTokens keysAndTokens)
        {
            return Tokens.Create(
                keysAndTokens.ApiKey,
                keysAndTokens.ApiSecretKey,
                keysAndTokens.AccessToken,
                keysAndTokens.AccessTokenSecret);
        }

        /// <summary>
        /// 指定したファイル パスに含まれる、パスとして使用できない文字を削除して返します。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string RemoveInvalidPathChars(string path)
        {
            var result = new StringBuilder(path);
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                result.Replace(c.ToString(), "");
            }
            return result.ToString();
        }

        private void ReportDetailReport()
        {
            const string Separator = "\t";

            string path = RemoveInvalidPathChars(MacroExpander.ExpandAll(config.FuhaReports.DetailReportFilePath));
            using var writer = new StreamWriter(path, false, reportFileEncoidng);

            writer.WriteLine(string.Join(Separator, new[] {
                "順番",
                "ツイート日時",
                "ツイートID",
                "ユーザー名",
                "@ID",
                "ツイート内容",
            }));

            int rank = 1;
            collectedTweets.ForEach(t =>
            {
                writer.WriteLine(string.Join(Separator, new[]
                {
                    rank.ToString(),
                    t.TweetedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                    t.Id.ToString(),
                    t.UserName,
                    t.FormatedUserScreenName,
                    t.EscapedText,
                }));
                rank++;
            });
        }

        private void ReportTweetReport()
        {
            Tweet? lastBossTweet = GetLastBossTweet();

            string path = RemoveInvalidPathChars(MacroExpander.ExpandAll(config.FuhaReports.TweetReportFilePath));
            using var writer = new StreamWriter(path, false, reportFileEncoidng);

            writer.WriteLine("本日のフハツイランキング");

            if (lastBossTweet == null)
            {
                writer.WriteLine();
                writer.WriteLine("ラスボスのツイートが見つからなかった為、集計できませんでした");
                return;
            }

            bool isFlyingStart = true;
            int rank = -1; // -1: フライングツイート, 1以降: ツイート順位

            collectedTweets.ForEach(t =>
            {
                // ラスボスアカウントのツイートになったタイミングから順位付け開始
                // それより前はフライング扱い
                if (t.UserScreenName == config.RankingCollection.RankingBaseId)
                {
                    isFlyingStart = false;
                    rank = 1;
                    return;
                }

                var tweet = new FuhaTweet(t, lastBossTweet, rank);
                writer.WriteLine($"[{tweet.DifferenceFromLastBossTweetFlag}{tweet.DifferenceFromLastBossTweet:mm\\:ss\\.fff}]{tweet.DisplayRank}: {t.UserName}");
                if (!isFlyingStart) { rank++; }
            });

            writer.WriteLine();
            writer.Write($"[ ]内はラスボスのフリージオがツイートした時間({lastBossTweet.TweetedAt:HH:mm:ss.fff})からの差");
        }

        private Tweet? GetLastBossTweet() => collectedTweets
            .FirstOrDefault(t => t.UserScreenName == config.RankingCollection.RankingBaseId);
    }
}
