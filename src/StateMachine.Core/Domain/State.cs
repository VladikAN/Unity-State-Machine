using System.Collections.Generic;

namespace StateMachine.Core.Domain
{
    public class State : IState
    {
        public State(string name)
        {
            Name = name;
            Conditions = new List<ICondition>();
        }

        public string Name { get; }
        public IList<ICondition> Conditions { get; set; }

        public IState Update()
        {
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