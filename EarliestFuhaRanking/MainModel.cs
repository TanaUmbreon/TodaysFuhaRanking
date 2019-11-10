using System;
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
        private readonly ConfigRoot config = ConfigManager.GetDefaultConfigRoot();
        private readonly List<Status> tweets = new List<Status>();
        private readonly Encoding reportFileEncoidng = Encoding.UTF8;

        /// <summary>
        /// <see cref="MainModel"/> の新しいインスタンスを生成します。
        /// </summary>
        public MainModel() { }

        public void CollectTweets()
        {
            const string SearchWord = "(フハハハハ！|Q.ラスボスは？)";

            Tokens token = CreateTokens();
            long? maxId = null;
            DateTime today = DateTime.Today;

            tweets.Clear();

            for (int i = 0; i < config.MaxQueryIterationCount; ++i)
            {
                try
                {
                    // ホームタイムラインからツイートを取得
                    // max_idに指定したツイートは直前のループで処理しているので除外(2ループ目以降)
                    // 今日ツイートされたものだけ取得
                    var statuses = token.Statuses
                        .HomeTimeline(count => config.CountPerQuery,
                                      exclude_replies => true,
                                      max_id => maxId)
                        .Skip(maxId == null ? 0 : 1)
                        .Where(s => s.CreatedAt.LocalDateTime.Date == today);

                    if (!statuses.Any()) { break; }

                    // さらにフハツイだけ取得
                    tweets.AddRange(statuses.Where(s => Regex.IsMatch(s.Text,SearchWord)));

                    maxId = statuses.LastOrDefault()?.Id;
                }
                catch (TwitterException ex)
                {
                    // 回数制限などでエラーの場合は問い合わせを中断するが、後続の処理は続行する
                    ConsoleApplication.WriteError(ex);
                    Environment.ExitCode = ConsoleException.DefaultExitCode;
                    break;
                }
            }

            tweets.Reverse();
        }

        private Tokens CreateTokens()
        {
            return Tokens.Create(
                config.KeysAndTokens.ApiKey,
                config.KeysAndTokens.ApiSecretKey,
                config.KeysAndTokens.AccessToken,
                config.KeysAndTokens.AccessTokenSecret);
        }

        public void ReportTweets()
        {
            ReportDetail();
            ReportForTweet();
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

        private void ReportDetail()
        {
            const string Separator = "\t";

            string path = RemoveInvalidPathChars(MacroExpander.ExpandAll(config.DetailReportFilePath));
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
            tweets.ForEach(s =>
            {
                writer.WriteLine(string.Join(Separator, new[]
                {
                    rank.ToString(),
                    ToDateTime(s.Id).ToString("yyyy-MM-dd HH:mm:ss.fff"),
                    s.Id.ToString(),
                    s.User.Name,
                    $"@{s.User.ScreenName}",
                    s.Text.Replace("\n","\\n"), // 改行をエスケープ
                }));
                rank++;
            });
        }

        private void ReportForTweet()
        {
            // ラスボスアカウントID(順位の基準ID)
            const string RankingBaseId = "rasubosufrijio";

            string path = RemoveInvalidPathChars(MacroExpander.ExpandAll(config.ReportForTweetFilePath));
            using var writer = new StreamWriter(path, false, reportFileEncoidng);

            writer.WriteLine("本日のフハツイランキング");

            bool isFlyingStart = true;
            int rank = -1; // -1: フライングツイート, 0: ラスボスのツイート, 1以降: ツイート順位
            tweets.ForEach(s =>
            {
                // ラスボスアカウントのツイートになったタイミングから順位付け開始
                // それより前はフライング扱い
                if (s.User.ScreenName == RankingBaseId)
                {
                    isFlyingStart = false;
                    rank = 0;
                }

                string r = isFlyingStart ? "フライング" : rank.ToString() + "位";
                writer.WriteLine($"[{ToDateTime(s.Id):HH:mm:ss.fff}]{r}: {s.User.Name}");
                if (!isFlyingStart) { rank++; }
            });
        }

        private DateTime ToDateTime(long tweetId)
        {
            // 算出方法の参考元
            // https://yoshipc.net/tweet-id-to-mili-sec/

            const long SnowflakeBeginTimestamp = 1288834974657L;
            long timestamp = (tweetId >> 22) + SnowflakeBeginTimestamp;
            return DateTimeOffset.FromUnixTimeMilliseconds(timestamp).LocalDateTime;
        }
    }
}
