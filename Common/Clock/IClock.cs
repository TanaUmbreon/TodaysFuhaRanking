using System;

namespace Common.Clock
{
    /// <summary>
    /// 時刻を提供します。
    /// </summary>
    public interface IClock
    {
        /// <summary>
        /// 現在日時を取得します。
        /// </summary>
        DateTime Now { get; }
    }
}
