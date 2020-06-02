using System;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace TodaysFuhaRanking.Commands
{
    public class ReportCommand : LoggableCommand
    {
        /// <summary>
        /// <see cref="ReportCommand"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="logger">コマンドの実行中に使用するロギング オブジェクト。</param>
        public ReportCommand(ILogger logger) : base(logger) { }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
