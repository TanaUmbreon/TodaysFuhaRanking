using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace TodaysFuhaRanking.Common.Macros
{
    /// <summary>
    /// 文字列置換マクロを一括置換します。
    /// </summary>
    public static class MacroExpander
    {
        /// <summary>一括置換として使用される全マクロ</summary>
        private static List<IMacro>? macros = null;

        /// <summary>
        /// 指定した文字列に含まれるマクロを展開して返します。
        /// </summary>
        /// <param name="input">文字列置換マクロが含まれる文字列。</param>
        /// <returns>文字列置換マクロが展開された文字列。</returns>
        public static string ExpandAll(string input)
        {
            macros ??= LoadMacros();

            string result = input;
            macros.ForEach(m => result = m.Expand(result));
            return result;
        }

        /// <summary>
        /// アセンブリ内の <see cref="IMacro"/> インタフェースを実装する全ての具象クラスのインスタンスを生成してリストとして返します。
        /// </summary>
        /// <returns></returns>
        private static List<IMacro> LoadMacros()
        {
            var result = new List<IMacro>();

            // IMacroを実装する具象クラスでデフォルトコンストラクタが存在するクラスを取得
            // そのクラスのインスタンスを作成し、リストに追加
            var targetInterface = typeof(IMacro);
            Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => targetInterface.IsAssignableFrom(t) && !t.IsAbstract)
                .ToList()
                .ForEach(t =>
                {
                    if (t.GetConstructor(Type.EmptyTypes)?.Invoke(null) is IMacro macro) { result.Add(macro); }
                });

            return result;
        }
    }
}
