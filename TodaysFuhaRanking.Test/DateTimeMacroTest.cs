using System;
using NUnit.Framework;
using TodaysFuhaRanking.Common.Clocks;
using TodaysFuhaRanking.Common.Macros;

namespace TodaysFuhaRanking.Test
{
    public class DateTimeMacroTest
    {

        [Test]
        public void Expand()
        {
            DateTime now = Convert.ToDateTime("2019/1/8 01:09:07.197");
            const string DefaultDateTimeValue = "2019/01/08 1:09:07";
            var m = new DateTimeMacro(new StoppedClock(now));

            Assert.That(() => m.Expand(null!), Throws.ArgumentNullException);
            Assert.That(m.Expand(""), Is.EqualTo(""));

            // "$(DateTime)"の形でなければマクロと認識しない
            // DateTimeの前後や、DateとTimeの単語間に余分な文字が含まれるとマクロと認識しない
            Assert.That(m.Expand("$(DateTime )"), Is.EqualTo("$(DateTime )"));
            Assert.That(m.Expand("$(Date Time)"), Is.EqualTo("$(Date Time)"));
            Assert.That(m.Expand("$(Date_Time)"), Is.EqualTo("$(Date_Time)"));
            // 大文字小文字は区別する。"DateTime"でなければマクロと認識しない
            Assert.That(m.Expand("$(datetime)"), Is.EqualTo("$(datetime)"));
            Assert.That(m.Expand("$(DATETIME)"), Is.EqualTo("$(DATETIME)"));
            // "$("で始まり")"で終わらなければマクロと認識しない
            Assert.That(m.Expand("$(DateTime"), Is.EqualTo("$(DateTime"));
            Assert.That(m.Expand("$DateTime"), Is.EqualTo("$DateTime"));
            Assert.That(m.Expand("($DateTime)"), Is.EqualTo("($DateTime)"));

            // 書式指定文字列なしパターン
            Assert.That(m.Expand("$(DateTime)"), Is.EqualTo(DefaultDateTimeValue));
            Assert.That(m.Expand("$(DateTime|)"), Is.EqualTo(DefaultDateTimeValue));
            Assert.That(m.Expand("filename_$(DateTime) $(DateTime)"), Is.EqualTo($"filename_{DefaultDateTimeValue} {DefaultDateTimeValue}"));
            Assert.That(m.Expand("$(DateTime$(DateTime))"), Is.EqualTo($"$(DateTime{DefaultDateTimeValue})"));
            Assert.That(m.Expand("($(DateTime))"), Is.EqualTo($"({DefaultDateTimeValue})"));

            // 書式指定文字列ありパターン
            Assert.That(m.Expand("$(DateTime|yyyyMMddHHmmssfff)"), Is.EqualTo("20190108010907197"));
            Assert.That(m.Expand("$(DateTime|yyyy/MM/dd HH:mm:ss.fff)"), Is.EqualTo("2019/01/08 01:09:07.197"));
            Assert.That(m.Expand("$(DateTime|yyyyMMdd)"), Is.EqualTo("20190108"));
            Assert.That(m.Expand("$(DateTime|$DateTime)"), Is.EqualTo("$Da午eTi9e"));
            Assert.That(m.Expand("$(DateTime|$(DateTime))"), Is.EqualTo("$(Da午eTi9e)"));
            Assert.That(m.Expand("$(DateTime|yyyy/MM/dd) $(DateTime|HH:mm:ss).$(DateTime|fff)"), Is.EqualTo("2019/01/08 01:09:07.197"));
        }
    }
}