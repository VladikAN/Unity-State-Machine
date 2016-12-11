using NUnit.Framework;
using StateMachine.Core.Domain;

namespace StateMachine.Tests.Domain
{
    [TestFixture]
    public class StateMachineTests
    {
        [Test]
        public void Update_DefaultValue_CurrentChanged()
        {
            var state = new State("State");

            var stateMachine = new Core.Domain.StateMachine
            {
                CurrentState = null,
                DefaultState = state
            };

            stateMachine.Add(state);
            stateMachine.Update();

            Assert.AreEqual(state, stateMachine.CurrentState);
        }

        public void Update_ConditionPassed_CurrentChanged()
        {
            var state1 = new State("State 1");
            var state2 = new State("State 2");

            var condition = new Condition(state1, state2, () => true);

            var stateMachine = new Core.Domain.StateMachine
            {
                 CurrentState = state1
            };

            stateMachine.Add(state1);
            stateMachine.Add(state2);
            stateMachine.Update();

            Assert.AreEqual(state2, stateMachine.CurrentState);
        }
    }
}