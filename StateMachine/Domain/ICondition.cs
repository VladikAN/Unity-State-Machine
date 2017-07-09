namespace StateMachine.Domain
{
    public interface ICondition
    {
        IState Parent { get; }
        IState Child { get; }

        bool Check();
    }
}