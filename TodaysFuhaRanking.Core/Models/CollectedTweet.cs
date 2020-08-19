using System;

namespace TodaysFuhaRanking.Core.Models
{
    public class CollectedTweet
    {
        public int TweetId { get; private set; }

        public int UserId { get; private set; }

        public string UserScreenName { get; private set; }

        public string UserName { get; private set; }

        public string Text { get; private set; }

        public DateTime TweetedAt { get; private set; }

        public DateTime TweetedDate => TweetedAt.Date;

        public TimeSpan TweetedTime => TweetedAt.TimeOfDay;

        /// <summary>
        /// <see cref="CollectedTweet"/> の新しいインスタンスを生成します。
        /// </summary>
        public CollectedTweet(int tweetedId, int userId, string userScreenName, string userName, string text, DateTime tweetedAt)
        {
            TweetId = tweetedId;
            UserId = userId;
            UserScreenName = userScreenName;
            UserName = userName;
            Text = text;
            TweetedAt = tweetedAt;
        }
    }
}
