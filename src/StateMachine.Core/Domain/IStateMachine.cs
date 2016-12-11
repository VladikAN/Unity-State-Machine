namespace StateMachine.Core.Domain
{
    public interface IStateMachine
    {
        IState DefaultState { get; }
        IState CurrentState { get; }

        void Add(IState state);
        void Remove(IState state);
        void Update();
    }
}