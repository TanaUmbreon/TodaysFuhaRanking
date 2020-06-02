namespace TodaysFuhaRanking.Settings
{
    /// <summary>
    /// ルートとなるアプリケーション設定を表します。
    /// </summary>
    public class SettingsRoot
    {
        /// <summary>
        /// Twitter での操作設定を取得または設定します。
        /// </summary>
        public TwitterOperationSettings TwitterOperation { get; set; } = new TwitterOperationSettings();

        /// <summary>
        /// 集計したフハ ツイートの保管設定を取得または設定します。
        /// </summary>
        public FuhaTweetStorageSettings FuhaTweetStorage { get; set; } = new FuhaTweetStorageSettings();

        /// <summary>
        /// テキスト ファイルによるフハ レポートの出力設定を取得または設定します。
        /// </summary>
        public TextReportSettings TextReport { get; set; } = new TextReportSettings();

        /// <summary>
        /// <see cref="SettingsRoot"/> の新しいインスタンスを生成します。
        /// </summary>
        public SettingsRoot() { }
    }
}
