using System;

namespace TodaysFuhaRanking.Common.Clocks
{
    /// <summary>
    /// このコンピューターのローカル時刻を提供します。
    /// </summary>
    public class LocalClock : IClock
    {
        /// <summary>
        /// このコンピューターの現在日時を取得します。
        /// </summary>
        public DateTime Now => DateTime.Now;
    }
}
