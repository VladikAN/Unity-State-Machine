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

        [Test]
        public void Build_ConditionLinked()
        {
            var state1 = new State("State 1");
            var state2 = new State("State 2");

            var result = Condition.Build(state1, state2, () => true);

            Assert.AreEqual(1, state1.Conditions.Count);
            Assert.AreEqual(result, state1.Conditions[0]);
            Assert.AreEqual(state1, result.Parent);
            Assert.AreEqual(state2, result.Child);
        }
    }
}