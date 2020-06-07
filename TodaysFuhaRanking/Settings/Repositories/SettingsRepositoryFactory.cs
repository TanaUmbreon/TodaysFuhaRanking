using System.IO;
using TodaysFuhaRanking.Common;

namespace TodaysFuhaRanking.Settings.Repositories
{
    /// <summary>
    /// <see cref="ISettingRepository"/> を実装するオブジェクトを生成するファクトリーです。
    /// </summary>
    public static class SettingsRepositoryFactory
    {
        /// <summary>
        /// 既定の <see cref="ISettingRepository"/> のインスタンスを生成します。
        /// </summary>
        /// <returns>既定の <see cref="ISettingRepository"/> のインスタンス。</returns>
        public static ISettingsRepository CreateDefault()
        {
            string path = Path.Combine(AssemblyInfo.DirectoryPath, "Settings.json");

            return new JsonSettingsRepository(path);
        }
    }
}
