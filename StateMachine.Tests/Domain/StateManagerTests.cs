using StateMachine.Domain;
using Xunit;

namespace StateMachine.Tests.Domain
{
    public class StateManagerTests
    {
        [Fact]
        public void Ctor_ParamsPassed_DefaultAndCurrentSet()
        {
            var currentState = new State("State 1");
            var defaultState = new State("State 2");

            var stateMachine = new StateManager(currentState, defaultState);

            Assert.Equal(currentState, stateMachine.CurrentState);
            Assert.Equal(defaultState, stateMachine.DefaultState);
        }

        [Fact]
        public void Add_FirstState_CurrentChanged()
        {
            var state = new State("State");
            var stateMachine = new StateManager();

            stateMachine.Add(state);

            Assert.Equal(state, stateMachine.CurrentState);
        }

        [Fact]
        public void Add_SecondState_CurrentNotChanged()
        {
            var state1 = new State("State 1");
            var state2 = new State("State 1");
            var stateMachine = new StateManager();

            stateMachine.Add(state1);
            stateMachine.Add(state2);

            Assert.Equal(state1, stateMachine.CurrentState);
        }

        [Fact]
        public void Update_ConditionPassed_CurrentChanged()
        {
            var currentState = new State("State 1");
            var nextState = new State("State 2");
            var condition = new Condition(currentState, nextState, () => true);
            currentState.Conditions.Add(condition);

            var stateMachine = new StateManager(currentState);

            stateMachine.Add(nextState);
            stateMachine.Update();

            Assert.Equal(nextState, stateMachine.CurrentState);
        }

        [Fact]
        public void UpdateNoCheck_Condition_ConditionNotExecuted()
        {
            var currentState = new State("State 1");
            var nextState = new State("State 2");
            var condition = new Condition(currentState, nextState, () => true);
            currentState.Conditions.Add(condition);

            var stateMachine = new StateManager(currentState);

            stateMachine.Add(nextState);
            stateMachine.UpdateNoCheck();

            Assert.Equal(currentState, stateMachine.CurrentState);
        }
    }
}