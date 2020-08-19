﻿namespace TodaysFuhaRanking.Core.Settings
{
    /// <summary>
    /// フハ ツイートの集計オプションを表します。
    /// </summary>
    public class AggregationOptions
    {
        /// <summary>オプションのキー名</summary>
        public const string KeyName = "Aggregation";

        /// <summary>
        /// 一度のタイムライン問い合わせで取得する最大ツイート数を取得または設定します。
        /// </summary>
        public int CountPerQuery { get; set; } = 0;

        /// <summary>
        /// タイムライン問い合わせを繰り返す回数を取得または設定します。
        /// </summary>
        /// <remarks>Twitter APIの仕様上、タイムライン問い合わせは15分あたり15回までです。</remarks>
        public int MaxQueryIterationCount { get; set; } = 0;

        /// <summary>
        /// ランキング対象のツイートを抽出する検索ワードを取得または設定します。
        /// </summary>
        /// <remarks>部分一致で検索を行い、全角半角や大文字小文字などは区別します。正規表現での記述に対応しています。</remarks>
        public string SearchWord { get; set; } = "";

        /// <summary>
        /// 順位の基準となるラスボスアカウントの @ID を取得または設定します。
        /// </summary>
        public string RankingBaseId { get; set; } = "";

        /// <summary>
        /// <see cref="AggregationOptions"/> の新しいインスタンスを生成します。
        /// </summary>
        public AggregationOptions() { }
    }
}