namespace TodaysFuhaRanking.Settings.Repositories
{
    /// <summary>
    /// <see cref="ISettingRepository"/> を実装するオブジェクトを生成するファクトリーです。
    /// </summary>
    public static class SettingsRepositoryFactory
    {
        /// <summary>既定のコンフィグ情報ファイルのパス</summary>
        private const string DefaultSettingsFilePath = "Settings.json";

        /// <summary>
        /// 既定の <see cref="ISettingRepository"/> のインスタンスを生成します。
        /// </summary>
        /// <returns>既定の <see cref="ISettingRepository"/> のインスタンス。</returns>
        public static ISettingsRepository CreateDefault()
        {
            return new JsonSettingsRepository(DefaultSettingsFilePath);
        }
    }
}
