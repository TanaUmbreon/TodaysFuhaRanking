namespace TodaysFuhaRanking.Settings.Repositories
{
    /// <summary>
    /// 永続化されたアプリケーション設定を操作する機能を実装します。
    /// </summary>
    public interface ISettingsRepository
    {
        /// <summary>
        /// 永続化されたアプリケーション設定を読み込み、そのインスタンスを返します。
        /// </summary>
        /// <returns>読み込んだアプリケーション設定。</returns>
        SettingsRoot Load();
    }
}
