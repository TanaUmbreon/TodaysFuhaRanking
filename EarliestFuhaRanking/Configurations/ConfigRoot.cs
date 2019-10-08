using System;
using System.Collections.Generic;
using System.Text;

namespace EarliestFuhaRanking.Configurations
{
    /// <summary>
    /// アプリケーションの構成情報を格納します。
    /// </summary>
    public class ConfigRoot
    {
        public KeysAndTokens KeysAndTokens { get; set; } = new KeysAndTokens();

        /// <summary>
        /// <see cref="ConfigRoot"/> の新しいインスタンスを生成します。
        /// </summary>
        public ConfigRoot() { }
    }
}
