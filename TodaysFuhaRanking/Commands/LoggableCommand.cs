using System;
using System.Windows.Input;
using NLog;

namespace TodaysFuhaRanking.Commands
{
    /// <summary>
    /// ロギングが可能なコマンドの基底クラスを表します。
    /// </summary>
    public abstract class LoggableCommand : ICommand
    {
        /// <summary>
        /// ロギング オブジェクトを取得します。
        /// </summary>
        protected ILogger Logger { get; }

        /// <summary>
        /// コマンドを実行するかどうかに影響するような変更があった場合に発生します。
        /// </summary>
        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// <see cref="LoggableCommand"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="logger">コマンドの実行中に使用するロギング オブジェクト。</param>
        /// <remarks>コマンドの実行に必要なパラメーターはコンストラクタの引数で渡すようにします。</remarks>
        protected LoggableCommand(ILogger logger)
        {
            Logger = logger;

            CanExecuteChanged = null;
        }

        /// <summary>
        /// 現在の状態でコマンドが実行可能かどうかを決定するメソッドを定義します。
        /// </summary>
        /// <param name="parameter">コマンドにより使用されるデータです。コマンドにデータを渡す必要がない場合は、このオブジェクトを null に設定できます。</param>
        /// <returns>このコマンドを実行できる場合は、true。それ以外の場合は、false。</returns>
        public virtual bool CanExecute(object parameter) => true;

        /// <summary>
        /// コマンドが起動される際に呼び出すメソッドを定義します。
        /// </summary>
        /// <param name="parameter">コマンドにより使用されるデータです。コマンドにデータを渡す必要がない場合は、このオブジェクトを null に設定できます。</param>
        public abstract void Execute(object parameter);

        /// <summary>
        /// <see cref="CanExecuteChanged"/> イベントを発生させます。
        /// </summary>
        protected void OnCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
