using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace TodaysFuhaRanking.Settings.Repositories
{
    /// <summary>
    /// JSON ファイル形式で実装されたアプリケーション設定を操作する機能を提供します。
    /// </summary>
    public class JsonSettingsRepository : ISettingsRepository
    {
        /// <summary>操作するアプリケーション設定ファイル</summary>
        private readonly FileInfo settingsFile;
        /// <summary>操作するアプリケーション設定ファイルの文字エンコーディング</summary>
        private readonly Encoding encoding;

        /// <summary>
        /// アプリケーション設定ファイルのパスを指定して、
        /// <see cref="JsonSettingsRepository"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="path">操作するアプリケーション設定ファイルのパス。</param>
        public JsonSettingsRepository(string path)
        {
            var _ = path ?? throw new ArgumentNullException(nameof(path));

            settingsFile = new FileInfo(path);

            if (!settingsFile.Exists) { throw new FileNotFoundException(
                $"アプリケーション設定ファイル ({settingsFile.FullName}) が見つかりません。"); }

            encoding = Encoding.UTF8;
        }

        /// <summary>
        /// アプリケーション設定ファイルを読み込み、そのインスタンスを返します。
        /// </summary>
        /// <returns>読み込んだアプリケーション設定。</returns>
        public SettingsRoot Load()
        {
            using var source = new StreamReader(settingsFile.FullName, encoding);
            using var reader = new JsonTextReader(source);
            var serializer = new JsonSerializer();
            return serializer.Deserialize<SettingsRoot>(reader) ??
                throw new JsonException("アプリケーション設定ファイルを読み込みできません。");
        }
    }
}
