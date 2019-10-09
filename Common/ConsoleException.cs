using System;

namespace Common
{
    /// <summary>
    /// コンソール アプリケーションで発生したエラーを表します。
    /// </summary>
    public class ConsoleException : Exception
    {
        /// <summary>終了コードを指定しなかった場合の規定の終了コード</summary>
        public const int DefaultExitCode = 1;

        /// <summary>
        /// 終了コードを取得します。
        /// </summary>
        public int ExitCode { get; }

        /// <summary>
        /// 既定のエラー メッセージおよび終了コードを使用して、
        /// <see cref="ConsoleException"/> の新しいインスタンスを生成します。
        /// </summary>
        public ConsoleException() :
            this(DefaultExitCode)
        {
        }

        /// <summary>
        /// 指定した終了コードと既定のエラー メッセージを使用して、
        /// <see cref="ConsoleException"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="exitCode">終了コード。</param>
        public ConsoleException(int exitCode) :
            base()
        {
            ExitCode = exitCode;
        }

        /// <summary>
        /// 指定したエラー メッセージと既定の終了コードを使用して、
        /// <see cref="ConsoleException"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="message">エラーの原因を説明するメッセージ。</param>
        public ConsoleException(string message) :
            this(message, DefaultExitCode, null)
        {
        }

        /// <summary>
        /// 指定したエラー メッセージおよび終了コードを使用して、
        /// <see cref="ConsoleException"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="message">エラーの原因を説明するメッセージ。</param>
        /// <param name="exitCode">終了コード。</param>
        public ConsoleException(string message, int exitCode) :
            this(message, exitCode, null)
        {
        }

        /// <summary>
        /// 指定したエラー メッセージおよびこの例外の原因となった内部例外への参照と既定の終了コードを使用して、
        /// <see cref="ConsoleException"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="message">エラーの原因を説明するメッセージ。</param>
        /// <param name="innerException">現在の例外の原因である例外。内部例外が指定されていない場合は null 参照。</param>
        public ConsoleException(string message, Exception? innerException) :
            this(message, DefaultExitCode, innerException)
        {
        }

        /// <summary>
        /// 指定したエラー メッセージ、終了コードおよびこの例外の原因となった内部例外への参照を使用して、
        /// <see cref="ConsoleException"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="message">エラーの原因を説明するメッセージ。</param>
        /// <param name="exitCode">終了コード。</param>
        /// <param name="innerException">現在の例外の原因である例外。内部例外が指定されていない場合は null 参照。</param>
        public ConsoleException(string message, int exitCode, Exception? innerException) :
            base(message, innerException)
        {
            ExitCode = exitCode;
        }
    }
}
