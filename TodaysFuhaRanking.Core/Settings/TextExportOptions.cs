namespace TodaysFuhaRanking.Core.Settings
{
    /// <summary>
    /// テキスト ファイルによるフハ レポートの出力設定を表します。
    /// </summary>
    public class TextExportOptions
    {
        /// <summary>オプションのキー名</summary>
        public const string KeyName = "TextExport";

        /// <summary>
        /// フハ レポートの出力先フォルダーの相対パスまたは絶対パスを取得または設定します。
        /// </summary>
        /// <remarks>
        /// 値が空白の場合はカレント フォルダーと同値となります。
        /// 値が相対パスの場合はカレント フォルダーを起点とします。
        /// 文字列置換マクロに対応しています。
        /// </remarks>
        public string ExportDirectoryPath { get; set; } = "";

        /// <summary>
        /// 詳細フハ レポートの出力ファイル名を取得または設定します。
        /// </summary>
        /// <remarks>文字列置換マクロに対応しています。</remarks>
        public string DetailReportFileName { get; set; } = "";

        /// <summary>
        /// ツイート用フハ レポートの出力ファイル名を取得または設定します。
        /// </summary>
        /// <remarks>文字列置換マクロに対応しています。</remarks>
        public string TweetReportFileName { get; set; } = "";

        /// <summary>
        /// フハ レポートの文字エンコーディング名を取得または設定します。
        /// </summary>
        public string EncodingName { get; set; } = "";

        /// <summary>
        /// <see cref="TextExportOptions"/> の新しいインスタンスを生成します。
        /// </summary>
        public TextExportOptions() { }
    }
}
