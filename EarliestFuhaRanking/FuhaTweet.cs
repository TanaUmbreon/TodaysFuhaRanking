using System;
using System.Collections.Generic;
using System.Text;
using CoreTweet;

namespace EarliestFuhaRanking
{
    /// <summary>
    /// 単一のフハ ツイートを表します。
    /// </summary>
    public class FuhaTweet
    {
        /// <summary>
        /// 順位を取得します。
        /// </summary>
        public int Rank { get; }

        /// <summary>
        /// 画面表示上の順位を取得します。
        /// </summary>
        public string DisplayRank => Rank switch
        {
            int i when i < 0 => "フライング",
            int i => $"{i}位",
        };

        /// <summary>
        /// ラスボスとのツイートの時間差を取得します。
        /// </summary>
        public TimeSpan DifferenceFromLastBossTweet { get; }

        /// <summary>
        /// ツイートした日時を取得します。
        /// </summary>
        public string DifferenceFromLastBossTweetFlag => DifferenceFromLastBossTweet < TimeSpan.Zero ? "-" : "+";

        /// <summary>
        /// <see cref="FuhaTweet"/> の新しいインスタンスを生成します。
        /// </summary>
        public FuhaTweet(Tweet tweet, Tweet lastBossTweet, int rank)
        {
            Rank = rank;
            DifferenceFromLastBossTweet = tweet.TweetedAt - lastBossTweet.TweetedAt;
        }
    }
}
