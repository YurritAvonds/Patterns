namespace Patterns.Standard.State.Examples;

public class StateThree : IConcreteState
{
    public void Handle(ConcreteContext context)
    {
        context.Results.Add("Three");
    }
}
