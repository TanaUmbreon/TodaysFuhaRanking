using System;

namespace Common
{
    /// <summary>
    /// コンソール アプリケーションを実行するためのフレームワークを提供します。
    /// </summary>
    public static class ConsoleApplication
    {
        /// <summary>
        /// キャッチされていない例外をコンソール出力するときに使用するメッセージの文字色を取得または設定します。
        /// </summary>
        public static ConsoleColor ErrorColor { get; set; } = ConsoleColor.Yellow;

        /// <summary>
        /// 指定したメソッドをフレームワーク上で実行します。
        /// </summary>
        /// <param name="action">実行するメソッド。</param>
        /// <remarks>
        /// 指定したメソッドでキャッチされていない例外が発生した場合、
        /// その例外を説明するメッセージをコンソール出力し、さらに終了コードを設定します。
        /// 終了コードは、発生した例外が <see cref="ConsoleException"/> の場合は
        /// <see cref="ConsoleException.ExitCode"/> プロパティの値を設定し、
        /// それ以外の例外が発生した場合は <see cref="ConsoleException.DefaultExitCode"/> の値を設定します。
        /// </remarks>
        public static void Run(Action action)
        {
            try
            {
                if (action == null) { throw new ArgumentNullException(nameof(action)); }

                action.Invoke();
            }
            catch (ConsoleException ex)
            {
                WriteStopError(ex);
                Environment.ExitCode = ex.ExitCode;
            }
            catch (Exception ex)
            {
                WriteStopError(ex);
                Environment.ExitCode = ConsoleException.DefaultExitCode;
            }
        }

        /// <summary>
        /// 指定した例外を説明するメッセージをコンソール出力します。
        /// </summary>
        /// <param name="ex">メッセージをコンソール出力する例外。</param>
        private static void WriteStopError(Exception ex)
        {
            var prev = Console.ForegroundColor;
            Console.ForegroundColor = ErrorColor;
            Console.WriteLine("問題が発生したため、アプリケーションは終了しました。");
            Console.ForegroundColor = prev;
            WriteError(ex);
        }

        /// <summary>
        /// 指定した例外を説明するメッセージをコンソール出力します。
        /// </summary>
        /// <param name="ex">メッセージをコンソール出力する例外。</param>
        public static void WriteError(Exception ex)
        {
            var prev = Console.ForegroundColor;
            Console.ForegroundColor = ErrorColor;
            Console.WriteLine(ex.Message);
            Console.ForegroundColor = prev;
            Console.WriteLine();
            Console.WriteLine($"<{ex.GetType().Name}>");
            Console.WriteLine("StackTrace:");
            Console.WriteLine(ex.StackTrace);
        }
    }
}