using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using TodaysFuhaRanking.Core.Commands.Operators;

namespace TodaysFuhaRanking.Test.Commands.Operators
{
    [TestFixture]
    class CommandOtionsTest
    {
        [Test]
        public void TestNew()
        {
            Assert.That(() => new CommandOptions(), Throws.Nothing);
        }

        [Test]
        public void TestExecutesAggregate()
        {
            var o = new CommandOptions();
            Assert.That(o.ExecutesAggregate, Is.False);

            o.ExecutesAggregate = true;
            Assert.That(o.ExecutesAggregate, Is.True);
        }

        [Test]
        public void TestExecutesTweet()
        {
            var o = new CommandOptions();
            Assert.That(o.ExecutesTweet, Is.False);

            o.ExecutesTweet = true;
            Assert.That(o.ExecutesTweet, Is.True);
        }

        [Test]
        public void TestExecutesExportText()
        {
            var o = new CommandOptions();
            Assert.That(o.ExecutesExportText, Is.False);

            o.ExecutesExportText = true;
            Assert.That(o.ExecutesExportText, Is.True);
        }

        [Test]
        public void TestHasSpecfiedExecution()
        {
            ICommandOptions o = new CommandOptions();
            Assert.That(o.HasSpecfiedExecution, Is.False);
        }

        [TestCase(false, false, false, false)]
        [TestCase(true, false, false, true)]
        [TestCase(false, true, false, true)]
        [TestCase(false, false, true, true)]
        [TestCase(true, true, false, true)]
        [TestCase(true, false, true, true)]
        [TestCase(false, true, true, true)]
        [TestCase(true, true, true, true)]
        public void TestHasSpecfiedExecution(
            bool executesAggregate,
            bool executesTweet,
            bool executesExportText,
            bool expectedHasSpecfiedExecution)
        {
            ICommandOptions o = new CommandOptions();
            o.ExecutesAggregate = executesAggregate;
            o.ExecutesTweet = executesTweet;
            o.ExecutesExportText = executesExportText;
            Assert.That(o.HasSpecfiedExecution, Is.EqualTo(expectedHasSpecfiedExecution));
        }

        [TestCase(false, false, false)]
        [TestCase(false, false, false, "")]
        [TestCase(true, false, false, "--Aggregate")]
        [TestCase(false, false, false, "--aggregate")]
        [TestCase(true, true, false, "--Aggregate", "--Tweet")]
        [TestCase(true, true, true, "--Aggregate", "--Tweet", "--ExportText")]
        [TestCase(true, false, true, "--Aggregate", "--Fuhahahahaha", "--ExportText")]
        [TestCase(false, false, true, "--ExportText", "--Blacky", "--Ippai", "--Chuki")]
        public void TestParseFrom(
            bool expectedExecutesAggregate,
            bool expectedExecutesTweet,
            bool expectedExecutesExportText,
            params string[] args)
        {
            var o = CommandOptions.ParseFrom(args);
            Assert.That(o.ExecutesAggregate, Is.EqualTo(expectedExecutesAggregate));
            Assert.That(o.ExecutesTweet, Is.EqualTo(expectedExecutesTweet));
            Assert.That(o.ExecutesExportText, Is.EqualTo(expectedExecutesExportText));
        }
    }
}
