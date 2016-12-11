using NUnit.Framework;
using StateMachine.Core.Domain;

namespace StateMachine.Tests.Domain
{
    [TestFixture]
    public class ConditionTests
    {
        [Test]
        public void Check_TrueFunc_ExpectedValue()
        {
            var condition = new Condition(null, null, () => true);

            var result = condition.Check();

            Assert.IsTrue(result);
        }

        [Test]
        public void Check_FalseFunc_ExpectedValue()
        {
            var condition = new Condition(null, null, () => false);

            var result = condition.Check();

            Assert.IsFalse(result);
        }
    }
}