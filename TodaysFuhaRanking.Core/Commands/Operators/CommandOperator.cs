using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace TodaysFuhaRanking.Core.Commands.Operators
{
    /// <summary>
    /// コマンド ライン引数のオプション情報とサービス プロバイダーを元に、コマンドの操作を行います。
    /// </summary>
    public class CommandOperator
    {
        /// <summary>コマンド ライン引数のオプション情報</summary>
        private readonly ICommandOptions options;
        /// <summary>DI コンテナとして使用する構成済みのサービス プロバイダー</summary>
        private readonly IServiceProvider services;

        /// <summary>
        /// <see cref="CommandOperator"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="options">コマンド ライン引数のオプション情報。</param>
        /// <param name="services">DI コンテナとして使用する構成済みのサービス プロバイダー。</param>
        public CommandOperator(ICommandOptions options, IServiceProvider services)
        {
            this.options = options;
            this.services = services;
        }

        /// <summary>
        /// 実行可能なコマンドを全て実行します。
        /// </summary>
        public void Execute()
        {
            if (!options.HasSpecfiedExecution)
            {
                throw new InvalidOperationException("実行する機能が一つも指定されていません。");
            }

            foreach (var command in CreateCommands())
            {
                command.Execute();
            }
        }

        /// <summary>
        /// コマンドのコレクションを生成します。
        /// </summary>
        /// <returns>実行オプションを元に生成されたコマンドのコレクション。</returns>
        private IEnumerable<ICommand> CreateCommands()
        {
            if (options.ExecutesAggregate) { yield return services.GetService<AggregateCommand>(); }
            if (options.ExecutesTweet) { yield return services.GetService<TweetCommand>(); }
            if (options.ExecutesExportText) { yield return services.GetService<ExportTextCommand>(); }
        }
    }
}
