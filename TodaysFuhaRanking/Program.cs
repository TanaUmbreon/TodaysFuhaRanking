using System;
using NLog;
using TodaysFuhaRanking.Commands.Operators;
using TodaysFuhaRanking.Common;

namespace TodaysFuhaRanking
{
    public static class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = LogManager.GetCurrentClassLogger();

            try
            {
                logger.Info("アプリケーションを開始します。");

                var oper = new CommandOperator(args);
                oper.ExecuteCommands();

                ExitCode.Completed.Apply();
                logger.Info("アプリケーションは正常終了しました。");
            }
            catch (Exception ex)
            {
                ExitCode.Stopped.Apply();
                logger?.Fatal(ex, "アプリケーションで問題が発生したため、実行を中断しました。");
                throw;
            }
        }

        #region 終了コードの定義

        /// <summary>
        /// 終了コードを表します。
        /// </summary>
        internal class ExitCode : Enumeration
        {
            /// <summary>正常終了</summary>
            public static readonly ExitCode Completed = new ExitCode(id: 0, name: "正常終了");
            /// <summary>異常終了</summary>
            public static readonly ExitCode Stopped = new ExitCode(id: 1, name: "異常終了");

            #region 列挙型クラスのインスタンス メンバ

            /// <summary>
            /// <see cref="ExitCode"/> の新しいインスタンスを生成します。
            /// </summary>
            /// <param name="id">終了コードを一意に特定する為の識別子。終了コードそのもの。</param>
            /// <param name="name">終了コードの説明。</param>
            private ExitCode(int id, string name) : base(id, name) { }

            /// <summary>
            /// このインスタンスの終了コードをアプリケーションの戻り値として適用します。
            /// </summary>
            public void Apply() => Environment.ExitCode = Id;

            #endregion
        }

        #endregion
    }
}
