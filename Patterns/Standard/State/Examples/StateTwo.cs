namespace Patterns.Standard.State.Examples;

public class StateTwo : IConcreteState
{
    public void Handle(ConcreteContext context)
    {
        context.Results.Add("Two");
        context.SetState(new StateThree());
    }
}
