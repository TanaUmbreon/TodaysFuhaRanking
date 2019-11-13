using System;
using CoreTweet;

namespace EarliestFuhaRanking
{
    /// <summary>
    /// 単一のツイートを表します。
    /// </summary>
    public class Tweet
    {
        /// <summary>
        /// 単一のツイートを識別する ID を取得します。
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// ツイートの本文を取得します。
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// 改行文字をエスケープしたツイートの本文を取得します。
        /// </summary>
        public string EscapedText => Text.Replace("\n", "\\n");

        /// <summary>
        /// ツイートした日時を取得します。
        /// </summary>
        public DateTime TweetedAt { get; }

        /// <summary>
        /// 単一のユーザーを識別する ID を取得します。
        /// </summary>
        public long UserId { get; }

        /// <summary>
        /// ユーザー表示名 (@ID) を取得します。
        /// </summary>
        public string UserScreenName { get; }

        /// <summary>
        /// 先頭に @ を付与してフォーマット済みのユーザー表示名 (@ID) を取得します。
        /// </summary>
        public string FormatedUserScreenName => "@" + UserScreenName;

        /// <summary>
        /// ユーザー名を取得します。
        /// </summary>
        public string UserName { get; }

        /// <summary>
        /// <see cref="Tweet"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="status">Twitter API から取得したツイート オブジェクト。</param>
        public Tweet(Status status)
        {
            Id = status.Id;
            Text = status.Text;
            TweetedAt = ToDateTime(status.Id);
            UserId = status.User.Id ?? 0L;
            UserScreenName = status.User.ScreenName;
            UserName = status.User.Name;
        }

        /// <summary>
        /// 指定したツイート ID からミリ秒単位まで含まれるツイート日時に変換して返します。
        /// </summary>
        /// <param name="tweetId"></param>
        /// <returns></returns>
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
