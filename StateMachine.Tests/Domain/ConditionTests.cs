using StateMachine.Domain;
using Xunit;

namespace StateMachine.Tests.Domain
{
    public class ConditionTests
    {
        [Fact]
        public void Check_TrueFunc_ExpectedValue()
        {
            var condition = new Condition(null, null, () => true);

            var result = condition.Check();

            Assert.True(result);
        }

        [Fact]
        public void Check_FalseFunc_ExpectedValue()
        {
            var condition = new Condition(null, null, () => false);

            var result = condition.Check();

            Assert.False(result);
        }

        [Fact]
        public void Build_ConditionLinked()
        {
            var state1 = new State("State 1");
            var state2 = new State("State 2");

            var result = Condition.Build(state1, state2, () => true);

            Assert.Equal(1, state1.Conditions.Count);
            Assert.Equal(result, state1.Conditions[0]);
            Assert.Equal(state1, result.Parent);
            Assert.Equal(state2, result.Child);
        }
    }
}