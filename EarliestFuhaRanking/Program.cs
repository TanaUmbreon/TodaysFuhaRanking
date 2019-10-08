using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Common;
using CoreTweet;
using EarliestFuhaRanking.Configurations;

namespace EarliestFuhaRanking
{
    class Program
    {
        private const int ErrorCode = 1;

        static void Main(string[] args)
        {
            try
            {
                ConfigRoot config = ReadConfig();
                Tokens token = CreateTokens(config);
                List<Status> tweets = QueryFuhaTweeets(token);
                WriteTweets(tweets);

            }
            catch (Exception ex)
            {
                WriteError(ex);
                Environment.ExitCode = ErrorCode;
            }
        }

        private static void WriteError(Exception ex)
        {
            Console.WriteLine("問題が発生したため、アプリケーションは終了しました。");
            Console.WriteLine(ex.Message);
            Console.WriteLine();
            Console.WriteLine($"<{ex.GetType().Name}>");
            Console.WriteLine("StackTrace:");
            Console.WriteLine(ex.StackTrace);
        }

        private static ConfigRoot ReadConfig()
        {
            const string FileName = "Config.json";
            string path = Path.Combine(AssemblyInfo.DirectoryPath, FileName);

            if (!File.Exists(path)) { 
                throw new FileNotFoundException($"コンフィグファイル ({FileName}) が見つかりません"); 
            }

            var reader = new JsonConfigReader(path);
            return reader.Read();
        }

        private static Tokens CreateTokens(ConfigRoot config)
        {
            return Tokens.Create(
                config.KeysAndTokens.ApiKey,
                config.KeysAndTokens.ApiSecretKey,
                config.KeysAndTokens.AccessToken,
                config.KeysAndTokens.AccessTokenSecret);
        }

        private static List<Status> QueryFuhaTweeets(Tokens token)
        {
            const int CountPerQuery = 200; // 1回あたりの問い合わせ件数
            const int MaxIterationCount = 3; // 問い合わせの繰り返し件数(APIの仕様上、15分あたり15回までの制限がある)
            const string Fuhahahaha = "フハハハハ！";

            var tweets = new List<Status>();

            long? maxId = null;
            for (int i = 0; i< MaxIterationCount; ++i)
            {
                try
                {
                    // ホームタイムラインからツイートを取得
                    var result = token.Statuses.HomeTimeline(
                        count => CountPerQuery,
                        exclude_replies => true,
                        max_id => maxId);

                    if (result.Count == 0) { break; }

                    // max_idに指定したツイートは直前のループで処理しているので除外
                    var excludedMaxId = result.Skip(maxId == null ? 0 : 1);
                    if (excludedMaxId.Count() == 0) { break; }

                    tweets.AddRange(excludedMaxId.Where(r => r.Text.Contains(Fuhahahaha)));

                    maxId = result.LastOrDefault()?.Id;
                }
                catch (TwitterException ex)
                {
                    // 回数制限などでエラーの場合は問い合わせを中断するが、後続の処理は続行する
                    WriteError(ex);
                    Environment.ExitCode = ErrorCode;
                    break;
                }
            }

            tweets.Reverse();
            return tweets;
        }

        private static void WriteTweets(List<Status> tweets)
        {
            const string FileName = "Result.txt";
            string path = Path.Combine(AssemblyInfo.DirectoryPath, FileName);
            using var writer = new StreamWriter(path, false, Encoding.UTF8);

            const string Separator = "\t";
            writer.WriteLine(String.Join(Separator, new[] {
                "順番",
                "ツイート日時",
                "ユーザー名 (@ID)",
                "ツイート内容",
            }));

            int rank = 1;
            tweets.ForEach(r =>
            {
                writer.WriteLine(String.Join(Separator, new[]
                {
                    rank.ToString(),
                    ToDateTime(r.Id).ToString("yyyy-MM-dd HH:mm:ss.fff"),
                    $"{r.User.Name} (@{r.User.ScreenName})",
                    r.Text.Replace("\n","\\n"), // 改行をエスケープ
                }));
                rank++;
            });
        }

        private static DateTime ToDateTime(long tweetId)
        {
            // 算出方法の参考元
            // https://yoshipc.net/tweet-id-to-mili-sec/

            const long SnowflakeBeginTimestamp = 1288834974657L;
            long timestamp = (tweetId >> 22) + SnowflakeBeginTimestamp;
            return DateTimeOffset.FromUnixTimeMilliseconds(timestamp).LocalDateTime;
        }
    }
}
