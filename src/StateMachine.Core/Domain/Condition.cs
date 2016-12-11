using System;

namespace StateMachine.Core.Domain
{
    public class Condition : ICondition
    {
        private readonly Func<bool> _action;

        public Condition(IState parent, IState child, Func<bool> action)
        {
            Parent = parent;
            Child = child;

            _action = action;
        }

        public IState Parent { get; }
        public IState Child { get; }

        public bool Check()
        {
            return _action();
        }
    }
}