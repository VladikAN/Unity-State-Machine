namespace StateMachine.Domain
{
    public interface IStateManager
    {
        IState DefaultState { get; }
        IState CurrentState { get; }

        void Add(IState state);
        void Remove(IState state);
        void Update();
    }
}