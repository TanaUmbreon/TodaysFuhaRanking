namespace TodaysFuhaRanking.Settings
{
    /// <summary>
    /// 集計したフハ ツイートの保管設定を表します。
    /// </summary>
    public class FuhaTweetStorageSettings
    {
        /// <summary>
        /// 保管先となるデータベースへの接続文字列を取得または設定します。
        /// </summary>
        public string ConnectionString { get; set; } = "";

        /// <summary>
        /// <see cref="FuhaTweetStorageSettings"/> の新しいインスタンスを生成します。
        /// </summary>
        public FuhaTweetStorageSettings() { }
    }
}
