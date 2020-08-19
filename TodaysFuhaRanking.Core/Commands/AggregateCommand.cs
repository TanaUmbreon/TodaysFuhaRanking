using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using TodaysFuhaRanking.Core.Settings;
using CoreTweet;
using CommandLine;

namespace TodaysFuhaRanking.Core.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class AggregateCommand : ICommand
    {
        /// <summary>ログ出力オブジェクト</summary>
        private readonly ILogger<AggregateCommand> logger;
        /// <summary>Twitter API オプション</summary>
        private readonly TwitterApiOptions apiOptions;

        /// <summary>
        /// <see cref="AggregateCommand"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="logger">ログ出力オブジェクト</param>
        /// <param name="apiOptions">Twitter API オプション</param>
        public AggregateCommand(ILogger<AggregateCommand> logger, TwitterApiOptions apiOptions)
        {
            this.logger = logger;
            this.apiOptions = apiOptions;
        }

        public void Execute()
        {
            try
            {
                logger.LogInformation("本日のフハツイートを集計します。");


                logger.LogInformation("集計が完了しました。");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "集計中に問題が発生しました。処理を中断します。");
                throw;
            }
        }
    }
}
