namespace TodaysFuhaRanking.Core.Settings
{
    /// <summary>
    /// 集計したフハ ツイートの保管設定を表します。
    /// </summary>
    public class TweetStorageOptions
    {
        /// <summary>オプションのキー名</summary>
        public const string KeyName = "TweetStorage";

        /// <summary>
        /// 保管先となるデータベースへの接続文字列を取得または設定します。
        /// </summary>
        public string ConnectionString { get; set; } = "";

        /// <summary>
        /// <see cref="TweetStorageOptions"/> の新しいインスタンスを生成します。
        /// </summary>
        public TweetStorageOptions() { }
    }
}
