namespace TodaysFuhaRanking.Core.Commands.Operators
{
    /// <summary>
    /// コマンド ライン引数のオプション情報を格納する機能を提供します。
    /// </summary>
    public interface ICommandOptions
    {
        /// <summary>
        /// ランキングの集計機能を実行すること示す値を取得または設定します。
        /// </summary>
        bool ExecutesAggregate { get; set; }

        /// <summary>
        /// ランキングのツイート機能を実行すること示す値を取得または設定します。
        /// </summary>
        bool ExecutesTweet { get; set; }

        /// <summary>
        /// ランキングのテキスト出力機能を実行すること示す値を取得または設定します。
        /// </summary>
        bool ExecutesExportText { get; set; }

        /// <summary>
        /// 実行する機能が指定されていることを示す値を取得します。
        /// </summary>
        public bool HasSpecfiedExecution => ExecutesAggregate || ExecutesTweet || ExecutesExportText;
    }
}
