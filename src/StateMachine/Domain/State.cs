using System;
using System.Collections.Generic;

namespace StateMachine.Domain
{
    public class State : IState
    {
        private Action _job;

        public State(string name)
        {
            Name = name;
            Conditions = new List<ICondition>();
        }

        public State(string name, Action job)
        {
            Name = name;
            Conditions = new List<ICondition>();
            _job = job;
        }

        public string Name { get; }
        public IList<ICondition> Conditions { get; set; }

        public void UpdateNoCheck()
        {
            if (_job != null)
            {
                _job();
            }
        }

        public IState Update()
        {
            UpdateNoCheck();

            if (Conditions == null || Conditions.Count == 0)
            {
                return this;
            }

            for (var i = 0; i < Conditions.Count; i++)
            {
                if (Conditions[i].Check())
                {
                    return Conditions[i].Child;
                }
            }

            return this;
        }
    }
}