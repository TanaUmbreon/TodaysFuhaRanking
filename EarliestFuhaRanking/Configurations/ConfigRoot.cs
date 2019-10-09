namespace EarliestFuhaRanking.Configurations
{
    /// <summary>
    /// アプリケーションの構成情報を格納します。
    /// </summary>
    public class ConfigRoot
    {
        public KeysAndTokens KeysAndTokens { get; set; } = new KeysAndTokens();

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
        /// フハレポート ファイル (詳細) の保存先パスを取得または設定します。
        /// </summary>
        public string DetailReportFilePath { get; set; } = "";

        /// <summary>
        /// フハレポート ファイル (ツイート用) の保存先パスを取得または設定します。
        /// </summary>
        public string ReportForTweetFilePath { get; set; } = "";

        /// <summary>
        /// <see cref="ConfigRoot"/> の新しいインスタンスを生成します。
        /// </summary>
        public ConfigRoot() { }
    }
}
