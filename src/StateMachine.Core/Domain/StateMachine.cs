using System;
using System.Collections.Generic;

namespace StateMachine.Core.Domain
{
    public class StateMachine : IStateMachine
    {
        private readonly IList<IState> _states;

        public StateMachine()
        {
            _states = new List<IState>();
        }

        public IState DefaultState { get; set; }
        public IState CurrentState { get; set; }

        public void Add(IState state)
        {
            if (_states.IndexOf(state) == -1)
            {
                _states.Add(state);
            }
        }

        public void Remove(IState state)
        {
            if (_states.IndexOf(state) != -1)
            {
                _states.Remove(state);
            }
        }

        public void Update()
        {
            if (CurrentState == null)
            {
                CurrentState = DefaultState;
            }

            if (CurrentState == null)
            {
                return;
            }

            var state = CurrentState.Update();
            CurrentState = state;
        }
    }
}