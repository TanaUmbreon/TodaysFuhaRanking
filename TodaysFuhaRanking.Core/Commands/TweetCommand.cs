using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace TodaysFuhaRanking.Core.Commands
{
    public class TweetCommand : ICommand
    {
        private readonly ILogger<TweetCommand> logger;

        /// <summary>
        /// <see cref="TweetCommand"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="logger"></param>
        public TweetCommand(ILogger<TweetCommand> logger)
        {
            this.logger = logger;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
