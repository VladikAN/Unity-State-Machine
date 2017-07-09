using System;
using StateMachine.Domain;
using Xunit;

namespace StateMachine.Tests.Domain
{
    public class StateTests
    {
        [Fact]
        public void Update_EmptyConditions_ThisReturned()
        {
            var target = new State("State");

            var result = target.Update();

            Assert.Equal(result, target);
        }

        [Fact]
        public void Update_Conditions_ExpectedCondition()
        {
            var state1 = new State("State 1");
            var state2 = new State("State 2");
            var state3 = new State("State 3");

            var condition1 = new Condition(state1, state2, () => false);
            var condition2 = new Condition(state1, state3, () => true);

            state1.Conditions.Add(condition1);
            state1.Conditions.Add(condition2);

            var result = state1.Update();

            Assert.Equal(state3, result);
        }

        [Fact]
        public void Update_JobSpecified_JobCompleted()
        {
            var completed = false;
            Action job = () => { completed = !completed; };
            var state = new State("State", job);

            state.Update();

            Assert.True(completed);
        }

        [Fact]
        public void UpdateNoCheck_JobSpecified_JobCompleted()
        {
            var completed = false;
            Action job = () => { completed = !completed; };
            var state = new State("State", job);

            state.UpdateNoCheck();

            Assert.True(completed);
        }
    }
}