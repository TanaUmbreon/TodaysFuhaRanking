using System;
using System.Text.RegularExpressions;
using TodaysFuhaRanking.Common.Clocks;

namespace TodaysFuhaRanking.Common.Macros
{
    /// <summary>
    /// 現在の日時に置換するマクロです。
    /// </summary>
    public class DateTimeMacro : IMacro
    {
        /// <summary>日時の置換に使用する時刻取得アルゴリズム</summary>
        private readonly IClock clock;
        
        /// <summary>
        /// <see cref="DateTimeMacro"/> の新しいインスタンスを生成します。
        /// </summary>
        public DateTimeMacro() : this(new LocalClock()) { }

        /// <summary>
        /// 日時の置換に使用する時刻取得アルゴリズムを指定して、
        /// <see cref="DateTimeMacro"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="clock">日時の置換に使用する時刻取得アルゴリズム</param>
        public DateTimeMacro(IClock clock)
        {
            this.clock = clock;
        }

        /// <summary>
        /// 指定した文字列に含まれるマクロを展開して結果を返します。
        /// </summary>
        /// <param name="input">文字列置換マクロが含まれる文字列。</param>
        /// <returns>文字列置換マクロが展開された文字列。</returns>
        public string Expand(string input)
        {
            if (input == null) { throw new ArgumentNullException(nameof(input)); }

            var r = new Regex(pattern: @"\$\(DateTime(?:\|(.*?))?\)");
            string result = input;

            // 書式指定文字列ありの場合は出現の都度、書式の値が異なる場合があるので、
            // マッチした結果の前方から順番に1つずつ置換していく
            foreach (Match? m in r.Matches(input))
            {
                if (m == null) { continue; }

                // 2番目のグループに"$(DateTime|format)"の"format"部分が格納される
                // formatが指定されていればその値で日付の書式を指定する
                result = (m.Groups.Count > 1) && (m.Groups[1].Value != "")
                    ? r.Replace(input: result, replacement: clock.Now.ToString(m.Groups[1].Value), count: 1)
                    : r.Replace(input: result, replacement: clock.Now.ToString(), count: 1);
            }

            return result;
        }
    }
}
