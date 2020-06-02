using System;
using System.Text;

namespace TodaysFuhaRanking.Settings
{
    /// <summary>
    /// テキスト ファイルによるフハ レポートの出力設定を表します。
    /// </summary>
    public class TextReportSettings
    {
        /// <summary>
        /// フハ レポートの保存先フォルダーのパスを取得または設定します。
        /// </summary>
        public string SaveDirectoryPath { get; set; } = "";

        /// <summary>
        /// 詳細フハ レポートのファイル パスを取得または設定します。
        /// </summary>
        /// <remarks>文字列置換マクロに対応しています。</remarks>
        public string DetailReportFilePath { get; set; } = "";

        /// <summary>
        /// ツイート用フハ レポートのファイル パスを取得または設定します。
        /// </summary>
        /// <remarks>文字列置換マクロに対応しています。</remarks>
        public string TweetReportFilePath { get; set; } = "";

        /// <summary>
        /// フハ レポートの文字エンコーディング名を取得または設定します。
        /// </summary>
        public string EncodingName { get; set; } = "";

        /// <summary>
        /// <see cref="TextReportSettings"/> の新しいインスタンスを生成します。
        /// </summary>
        public TextReportSettings() { }

        /// <summary>
        /// フハ レポートの文字エンコーディングを取得します。
        /// </summary>
        /// <returns>フハ レポートの文字エンコーディング。</returns>
        public Encoding GetEncoding()
        {
            try
            {
                return Encoding.GetEncoding(EncodingName);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("フハ レポートの文字エンコーディング名が正しくありません。", ex);
            }
        }
    }
}
