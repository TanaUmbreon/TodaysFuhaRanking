﻿using System;
using System.Collections.Generic;
using System.Text;
using NLog;
using TodaysFuhaRanking.Settings;

namespace TodaysFuhaRanking.Commands
{
    /// <summary>
    /// ランキングのツイート機能を実行するコマンドです。
    /// </summary>
    public class TweetCommand : CommandBase
    {
        /// <summary>
        /// <see cref="TweetCommand"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="logger">コマンドの実行中に使用するロギング オブジェクト。</param>
        /// <param name="settings">コマンドの実行中に使用するアプリケーション設定。</param>
        public TweetCommand(ILogger logger, SettingsRoot settings) : base(logger, settings) { }

        protected override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
