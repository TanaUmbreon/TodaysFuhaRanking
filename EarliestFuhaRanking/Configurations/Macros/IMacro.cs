namespace EarliestFuhaRanking.Configurations.Macros
{
    /// <summary>
    /// 特定の文字列を特定の情報に置換するマクロを提供します。
    /// </summary>
    public interface IMacro
    {
        /// <summary>
        /// 指定した文字列に含まれるマクロを展開して結果を返します。
        /// </summary>
        /// <param name="input">文字列置換マクロが含まれる文字列。</param>
        /// <returns>文字列置換マクロが展開された文字列。</returns>
        string Expand(string input);
    }
}
