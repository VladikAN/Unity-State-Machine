using System.Collections.Generic;

namespace StateMachine.Core.Domain
{
    public class StateMachine : IStateMachine
    {
        private readonly IList<IState> _states;

        public StateMachine(IState currentState = null, IState defaultState = null)
        {
            _states = new List<IState>();

            if (currentState != null)
            {
                CurrentState = currentState;
                Add(CurrentState);
            }

            if (defaultState != null)
            {
                DefaultState = defaultState;
                Add(DefaultState);
            }
        }

        public IState DefaultState { get; private set; }
        public IState CurrentState { get; private set; }

        public void Add(IState state)
        {
            if (state == null)
            {
                return;
            }

            if (_states.IndexOf(state) == -1)
            {
                _states.Add(state);

                if (_states.Count == 1)
                {
                    CurrentState = state;
                }
            }
        }

        public void Remove(IState state)
        {
            if (state == null)
            {
                return;
            }

            if (_states.IndexOf(state) != -1)
            {
                _states.Remove(state);
            }
        }

        public void UpdateNoCheck()
        {
            if (CurrentState == null)
            {
                CurrentState = DefaultState;
            }

            if (CurrentState != null)
            {
                CurrentState.UpdateNoCheck();
            }
        }

        public void Update()
        {
            if (CurrentState == null)
            {
                CurrentState = DefaultState;
            }

            if (CurrentState != null)
            {
                var state = CurrentState.Update();
                CurrentState = state;
            }
        }
    }
}