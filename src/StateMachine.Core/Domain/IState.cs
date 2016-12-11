namespace StateMachine.Core.Domain
{
    public interface IState
    {
        string Name { get; }
        ICondition[] Conditions { get; set; }

        IState Update();
    }
}