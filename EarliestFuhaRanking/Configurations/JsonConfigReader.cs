using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace EarliestFuhaRanking.Configurations
{
    /// <summary>
    /// JSON 形式で保存されたアプリケーション構成ファイルを読み込む機能を提供します。
    /// </summary>
    public class JsonConfigReader
    {
        private string path;
        private Encoding encoding = Encoding.UTF8;

        /// <summary>
        /// ファイル パスを指定して <see cref="JsonConfigReader"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="path">読み込まれる完全なファイル パス。</param>
        public JsonConfigReader(string path)
        {
            if (path == null) { throw new ArgumentNullException(nameof(path)); }
            if (!File.Exists(path)) { throw new FileNotFoundException(); }

            this.path = path;
        }

        /// <summary>
        /// アプリケーション構成情報を読み込みオブジェクトとして返します。
        /// </summary>
        /// <returns>アプリケーション構成情報が格納されたオブジェクト。</returns>
        public ConfigRoot Read()
        {
            using var source = new StreamReader(path, encoding);
            using var reader = new JsonTextReader(source);
            var serializer = new JsonSerializer();
            return serializer.Deserialize<ConfigRoot>(reader);
        }
    }
}
