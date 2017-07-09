using System.Collections.Generic;

namespace StateMachine.Domain
{
    public interface IState
    {
        string Name { get; }
        IList<ICondition> Conditions { get; set; }

        void UpdateNoCheck();
        IState Update();
    }
}