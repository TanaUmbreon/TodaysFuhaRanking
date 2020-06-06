using System;
using System.Collections.Generic;
using CommandLine;

namespace TodaysFuhaRanking.Commands.Operators
{
    /// <summary>
    /// コマンド ラインのデータを格納するクラスを表します。
    /// </summary>
    public class CommandLineArgs
    {
        /// <summary>
        /// ランキングの集計機能を実行すること示す値を取得または設定します。
        /// </summary>
        [Option(longName: "Aggregate", Required = false)]
        public bool ExecutesAggregate { get; set; } = false;

        /// <summary>
        /// ランキングのツイート機能を実行すること示す値を取得または設定します。
        /// </summary>
        [Option(longName: "Tweet", Required = false)]
        public bool ExecutesTweet { get; set; } = false;

        /// <summary>
        /// ランキングのテキスト出力機能を実行すること示す値を取得または設定します。
        /// </summary>
        [Option(longName: "ExportText", Required = false)]
        public bool ExecutesExportText { get; set; } = false;

        /// <summary>
        /// <see cref="CommandLineArgs"/> の新しいインスタンスを生成します。
        /// </summary>
        public CommandLineArgs() { }

        /// <summary>
        /// 指定したコマンド ライン引数の生データを、それと等価な
        /// <see cref="CommandLineArgs"/> オブジェクトに変換します。
        /// </summary>
        /// <param name="args">変換するコマンド ライン引数の生データ。</param>
        /// <returns><paramref name="args"/> に格納されているデータと等価な <see cref="CommandLineArgs"/> オブジェクト。</returns>
        public static CommandLineArgs ParseFrom(IEnumerable<string> args)
        {
            // 未定義の引数は無視する
            using var p = new Parser(config => config.IgnoreUnknownArguments = true);

            return p.ParseArguments<CommandLineArgs>(args).MapResult(
                parsed => parsed,
                _ => throw new InvalidCastException("コマンド ライン引数の変換に失敗しました。")
                );
        }
    }
}
