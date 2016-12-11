namespace StateMachine.Core.Domain
{
    public class State : IState
    {
        public State(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public ICondition[] Conditions { get; set; }

        public IState Update()
        {
            if (Conditions == null || Conditions.Length == 0)
            {
                return this;
            }

            for (var i = 0; i < Conditions.Length; i++)
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