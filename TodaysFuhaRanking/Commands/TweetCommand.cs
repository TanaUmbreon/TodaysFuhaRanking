using System;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace TodaysFuhaRanking.Commands
{
    public class TweetCommand : LoggableCommand
    {
        /// <summary>
        /// <see cref="TweetCommand"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="logger">コマンドの実行中に使用するロギング オブジェクト。</param>
        public TweetCommand(ILogger logger) : base(logger) { }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
