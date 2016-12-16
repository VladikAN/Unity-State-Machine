using NUnit.Framework;
using StateMachine.Core.Domain;

namespace StateMachine.Tests.Domain
{
    [TestFixture]
    public class StateMachineTests
    {
        [Test]
        public void Ctor_ParamsPassed_DefaultAndCurrentSet()
        {
            var currentState = new State("State 1");
            var defaultState = new State("State 2");

            var stateMachine = new Core.Domain.StateMachine(currentState, defaultState);

            Assert.AreEqual(currentState, stateMachine.CurrentState);
            Assert.AreEqual(defaultState, stateMachine.DefaultState);
        }

        [Test]
        public void Add_FirstState_CurrentChanged()
        {
            var state = new State("State");
            var stateMachine = new Core.Domain.StateMachine();

            stateMachine.Add(state);

            Assert.AreEqual(state, stateMachine.CurrentState);
        }

        [Test]
        public void Add_SecondState_CurrentNotChanged()
        {
            var state1 = new State("State 1");
            var state2 = new State("State 1");
            var stateMachine = new Core.Domain.StateMachine();

            stateMachine.Add(state1);
            stateMachine.Add(state2);

            Assert.AreEqual(state1, stateMachine.CurrentState);
        }

        [Test]
        public void Update_ConditionPassed_CurrentChanged()
        {
            var currentState = new State("State 1");
            var nextState = new State("State 2");
            var condition = new Condition(currentState, nextState, () => true);
            currentState.Conditions.Add(condition);

            var stateMachine = new Core.Domain.StateMachine(currentState);

            stateMachine.Add(nextState);
            stateMachine.Update();

            Assert.AreEqual(nextState, stateMachine.CurrentState);
        }

        [Test]
        public void UpdateNoCheck_Condition_ConditionNotExecuted()
        {
            var currentState = new State("State 1");
            var nextState = new State("State 2");
            var condition = new Condition(currentState, nextState, () => true);
            currentState.Conditions.Add(condition);

            var stateMachine = new Core.Domain.StateMachine(currentState);

            stateMachine.Add(nextState);
            stateMachine.UpdateNoCheck();

            Assert.AreEqual(currentState, stateMachine.CurrentState);
        }
    }
}