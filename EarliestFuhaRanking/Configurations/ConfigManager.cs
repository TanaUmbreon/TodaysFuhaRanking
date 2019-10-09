using System.IO;

namespace EarliestFuhaRanking.Configurations
{
    public class ConfigManager
    {
        /// <summary>既定のアプリケーションの構成情報ファイルのパス</summary>
        private const string DefaultFilePath = "Config.json";

        /// <summary>
        /// 既定のアプリケーションの構成情報を取得します。
        /// </summary>
        /// <returns></returns>
        public static ConfigRoot GetDefaultConfigRoot()
        {
            if (!File.Exists(DefaultFilePath))
            {
                throw new FileNotFoundException($"コンフィグファイル ({DefaultFilePath}) が見つかりません");
            }

            var reader = new JsonConfigReader(DefaultFilePath);
            return reader.Read();
        }
    }
}
