using System;
using System.Collections.Generic;
using System.Text;
using NLog;
using Microsoft.Data.Sqlite;
using TodaysFuhaRanking.Settings;
using CoreTweet;

namespace TodaysFuhaRanking.Commands
{
    /// <summary>
    /// ランキングの集計機能を実行するコマンドです。
    /// </summary>
    public class AggregateCommand : CommandBase
    {
        /// <summary>
        /// <see cref="AggregateCommand"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="logger">コマンドの実行中に使用するロギング オブジェクト。</param>
        /// <param name="settings">コマンドの実行中に使用するアプリケーション設定。</param>
        public AggregateCommand(ILogger logger, SettingsRoot settings) : base(logger, settings) { }

        protected override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
