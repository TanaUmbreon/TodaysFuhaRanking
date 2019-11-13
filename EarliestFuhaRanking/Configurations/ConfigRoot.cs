namespace EarliestFuhaRanking.Configurations
{
    /// <summary>
    /// アプリケーションの構成情報を格納します。
    /// </summary>
    public class ConfigRoot
    {
        /// <summary>
        /// Twitter Developers で作成した App から発行される Consumer API keys および Access tokens の設定を取得または設定します。
        /// </summary>
        public KeysAndTokens KeysAndTokens { get; set; } = new KeysAndTokens();

        /// <summary>
        /// フハ レポートの出力設定を取得または設定します。
        /// </summary>
        public FuhaReports FuhaReports { get; set; } = new FuhaReports();

        /// <summary>
        /// ランキング集計の設定を取得または設定します。
        /// </summary>
        public RankingCollection RankingCollection { get; set; } = new RankingCollection();

        /// <summary>
        /// <see cref="ConfigRoot"/> の新しいインスタンスを生成します。
        /// </summary>
        public ConfigRoot() { }
    }
}
