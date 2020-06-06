using System;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace TodaysFuhaRanking.Commands
{
    /// <summary>
    /// ランキングの集計機能を実行するコマンドです。
    /// </summary>
    public class AggregateCommand : LoggableCommand
    {
        /// <summary>
        /// <see cref="AggregateCommand"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="logger">コマンドの実行中に使用するロギング オブジェクト。</param>
        public AggregateCommand(ILogger logger) : base(logger) { }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
