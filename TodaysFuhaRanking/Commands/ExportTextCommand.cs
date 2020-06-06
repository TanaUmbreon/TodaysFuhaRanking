using System;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace TodaysFuhaRanking.Commands
{
    /// <summary>
    /// ランキングのテキスト出力機能を実行するコマンドです。
    /// </summary>
    public class ExportTextCommand : LoggableCommand
    {
        /// <summary>
        /// <see cref="ExportTextCommand"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="logger">コマンドの実行中に使用するロギング オブジェクト。</param>
        public ExportTextCommand(ILogger logger) : base(logger) { }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
