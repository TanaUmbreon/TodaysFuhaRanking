using System;
using System.Windows.Input;
using NLog;
using TodaysFuhaRanking.Settings;

namespace TodaysFuhaRanking.Commands
{
    /// <summary>
    /// このアプリケーションで汎用的に使用する情報、操作を保持するコマンドの基底クラスを表します。
    /// </summary>
    public abstract class CommandBase : ICommand
    {
        /// <summary>
        /// ロギング オブジェクトを取得します。
        /// </summary>
        protected ILogger Logger { get; }

        /// <summary>
        /// アプリケーション設定を取得します。
        /// </summary>
        protected SettingsRoot Settings { get; }

        /// <summary>
        /// <see cref="CommandBase"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="logger">コマンドの実行中に使用するロギング オブジェクト。</param>
        /// <param name="settings">コマンドの実行中に使用するアプリケーション設定。</param>
        /// <remarks>コマンドの実行に必要なパラメーターはコンストラクタの引数で渡すようにします。</remarks>
        protected CommandBase(ILogger logger, SettingsRoot settings)
        {
            Logger = logger;
            Settings = settings;
        }

        #region ICommand 実装

        /// <summary>
        /// コマンドを実行するかどうかに影響するような変更があった場合に発生します。
        /// </summary>
        public event EventHandler? CanExecuteChanged = null;

        /// <summary>
        /// 現在の状態でコマンドが実行可能かどうかを決定するメソッドを定義します。
        /// </summary>
        /// <param name="parameter">コマンドにより使用されるデータです。コマンドにデータを渡す必要がない場合は、このオブジェクトを null に設定できます。</param>
        /// <returns>このコマンドを実行できる場合は、true。それ以外の場合は、false。</returns>
        /// <remarks>オーバーライドしない限り、<paramref name="parameter"/> は使用されません。</remarks>
        public virtual bool CanExecute(object parameter) => true;

        /// <summary>
        /// コマンドが起動される際に呼び出すメソッドを定義します。
        /// </summary>
        /// <param name="parameter">コマンドにより使用されるデータです。コマンドにデータを渡す必要がない場合は、このオブジェクトを null に設定できます。</param>
        /// <remarks>オーバーライドしない限り、<paramref name="parameter"/> は使用されません。</remarks>
        public void Execute(object parameter) => Execute();

        /// <summary>
        /// コマンドが起動される際に呼び出すメソッドを定義します。
        /// </summary>
        protected abstract void Execute();

        /// <summary>
        /// <see cref="CanExecuteChanged"/> イベントを発生させます。
        /// </summary>
        protected void OnCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        #endregion
    }
}
