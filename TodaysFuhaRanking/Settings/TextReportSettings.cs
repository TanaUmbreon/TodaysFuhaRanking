using System;
using System.IO;
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
        /// 詳細フハ レポートを出力するための書き出しストリームを生成します。
        /// </summary>
        /// <returns>詳細フハ レポートを出力するための書き出しストリーム。</returns>
        public TextWriter CreateDetailReportWriter()
        {
            if (string.IsNullOrEmpty(DetailReportFilePath))
            {
                throw new InvalidOperationException("詳細フハ レポートの出力先が設定されていません。");
            }

            string path = Path.Combine(SaveDirectoryPath, DetailReportFilePath);
            return new StreamWriter(path, false, GetEncoding());
        }

        /// <summary>
        /// ツイート用フハ レポートを出力するための書き出しストリームを生成します。
        /// </summary>
        /// <returns>ツイート用フハ レポートを出力するための書き出しストリーム。</returns>
        public TextWriter CreateTweetReportWriter()
        {
            if (string.IsNullOrEmpty(TweetReportFilePath))
            {
                throw new InvalidOperationException("ツイート用フハ レポートの出力先が設定されていません。");
            }

            string path = Path.Combine(SaveDirectoryPath, TweetReportFilePath);
            return new StreamWriter(path, false, GetEncoding());
        }

        /// <summary>
        /// フハ レポートの文字エンコーディングを取得します。
        /// </summary>
        /// <returns>フハ レポートの文字エンコーディング。</returns>
        private Encoding GetEncoding()
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
