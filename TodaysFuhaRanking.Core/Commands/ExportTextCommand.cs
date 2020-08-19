using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace TodaysFuhaRanking.Core.Commands
{
    public class ExportTextCommand : ICommand
    {
        private readonly ILogger<ExportTextCommand> logger;

        /// <summary>
        /// <see cref="ExportTextCommand"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="logger"></param>
        public ExportTextCommand(ILogger<ExportTextCommand> logger)
        {
            this.logger = logger;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
