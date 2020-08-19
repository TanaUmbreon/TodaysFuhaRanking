using System;
using Moq;
using NUnit.Framework;
using TodaysFuhaRanking.Core.Commands;
using TodaysFuhaRanking.Core.Commands.Operators;
using Microsoft.Extensions.DependencyInjection;

namespace TodaysFuhaRanking.Test.Commands.Operators
{
    [TestFixture]
    public class CommandOperatorTest
    {
        [Test]
        public void TestCreateNew()
        {
            var options = new Mock<ICommandOptions>();
            var services = new Mock<IServiceProvider>();
            Assert.That(() => new CommandOperator(options.Object, services.Object), Throws.Nothing);
        }

        [Test]
        public void TestExecute()
        {
            {
                var options = new Mock<ICommandOptions>();
                options.Setup(o => o.ExecutesAggregate).Returns(false);
                options.Setup(o => o.ExecutesTweet).Returns(false);
                options.Setup(o => o.ExecutesExportText).Returns(false);

                var services = new Mock<IServiceProvider>();

                var oper = new CommandOperator(options.Object, services.Object);
                Assert.That(() => oper.Execute(), Throws.InvalidOperationException);
            }
            // ToDo:
            // 例外が発生しないExecuteメソッドのテストパターンを別の手法で実装する。
            // Mock.Setupはvirtualなメンバーしか適用できない。
            //{
            //    var options = new Mock<ICommandOptions>();
            //    options.Setup(o => o.ExecutesAggregate).Returns(true);
            //    options.Setup(o => o.ExecutesTweet).Returns(false);
            //    options.Setup(o => o.ExecutesExportText).Returns(false);
            //
            //    //var command = new Mock<AggregateCommand>();
            //    //command.Setup(c => c.Execute()).Callback(() => { });
            //
            //    var services = new Mock<IServiceProvider>();
            //    //services.Setup(s => s.GetService<ICommand>()).Returns(command.Object);
            //
            //    var oper = new CommandOperator(options.Object, services.Object);
            //    Assert.That(() => oper.Execute(), Throws.Nothing);
            //}
        }
    }
}
