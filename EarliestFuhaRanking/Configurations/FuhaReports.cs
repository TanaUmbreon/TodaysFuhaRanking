using System;
using System.Text;

namespace EarliestFuhaRanking.Configurations
{
    /// <summary>
    /// フハ レポート出力の設定を格納します。
    /// </summary>
    public class FuhaReports
    {
        /// <summary>
        /// フハ レポートの文字エンコーディング名を取得または設定します。
        /// </summary>
        public string EncodingName { get; set; } = "";

        /// <summary>
        /// 詳細フハ レポートのファイル パスを取得または設定します。
        /// </summary>
        public string DetailReportFilePath { get; set; } = "";

        /// <summary>
        /// ツイート用フハ レポートのファイル パスを取得または設定します。
        /// </summary>
        public string TweetReportFilePath { get; set; } = "";

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
                throw new ArgumentException("レポート ファイルの文字エンコーディング名が正しくありません。", ex);
            }
        }
    }
}
