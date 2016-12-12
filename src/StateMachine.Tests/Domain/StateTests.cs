using System;
using NUnit.Framework;
using StateMachine.Core.Domain;

namespace StateMachine.Tests.Domain
{
    [TestFixture]
    public class StateTests
    {
        [Test]
        public void Update_EmptyConditions_ThisReturned()
        {
            var target = new State("State");

            var result = target.Update();

            Assert.AreEqual(result, target);
        }

        [Test]
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

            Assert.AreEqual(state3, result);
        }

        [Test]
        public void Update_JobSpecified_JobCompleted()
        {
            var completed = false;
            Action job = () => { completed = !completed; };
            var state = new State("State", job);

            state.Update();

            Assert.IsTrue(completed);
        }
    }
}