using System;

namespace TodaysFuhaRanking.Common.Clocks
{
    /// <summary>
    /// 固定された時刻を提供します。このクラスは単体テストで使用します。
    /// </summary>
    public class StoppedClock : IClock
    {
        /// <summary>
        /// <see cref="TestClock"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="now">固定された現在日時。</param>
        public StoppedClock(DateTime now)
        {
            Now = now;
        }

        /// <summary>
        /// 固定された現在日時を取得します。
        /// </summary>
        public DateTime Now { get; }
    }
}
