namespace TodaysFuhaRanking.Settings
{
    /// <summary>
    /// Twitter での操作設定を表します。
    /// </summary>
    public class TwitterOperationSettings
    {
        /// <summary>
        /// Twitter Developers で作成した App から発行される Consumer API keys および Access tokens の設定を取得または設定します。
        /// </summary>
        public KeysAndTokensSettings KeysAndTokens { get; set; } = new KeysAndTokensSettings();

        /// <summary>
        /// フハ ツイートの集計設定を取得または設定します。
        /// </summary>
        public FuhaTweetAggregationSettings FuhaTweetAggregation { get; set; } = new FuhaTweetAggregationSettings();

        /// <summary>
        /// <see cref="TwitterOperationSettings"/> の新しいインスタンスを生成します。
        /// </summary>
        public TwitterOperationSettings() { }
    }
}