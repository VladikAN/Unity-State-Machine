namespace StateMachine.Core.Domain
{
    public interface IStateMachine
    {
        IState DefaultState { get; set; }
        IState CurrentState { get; set; }

        void Add(IState state);
        void Remove(IState state);
        void Update();
    }
}