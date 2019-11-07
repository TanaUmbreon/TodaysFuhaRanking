using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Clock
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
