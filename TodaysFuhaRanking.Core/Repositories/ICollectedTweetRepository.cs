using System;
using System.Collections.Generic;
using TodaysFuhaRanking.Core.Models;

namespace TodaysFuhaRanking.Core.Repositories
{
    public interface ICollectedTweetRepository
    {
        bool Add(CollectedTweet tweet);

        /// <summary>
        /// 指定したツイート日付に一致するツイートをコレクションで返します。
        /// </summary>
        /// <param name="tweetedDate"></param>
        /// <returns></returns>
        IEnumerable<CollectedTweet> Get(DateTime tweetedDate);
    }
}
