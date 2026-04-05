namespace Patterns.Standard.State.Examples;

public class StateOne : IConcreteState
{
    public void Handle(ConcreteContext context)
    {
        context.Results.Add("One");
        context.SetState(new StateTwo());
    }
}
