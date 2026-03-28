namespace Patterns.Standard.Mediator;

/// <summary>
/// Just one possible implementation of a mediator. Because the components do not know about each other,
/// they can be reused with different mediators. The mediator can be changed without changing the components.
/// </summary>
public class Mediator : IMediator
{
    public ComponentA ComponentA { get; private set; }
    public ComponentB ComponentB { get; private set; }
    public ComponentC ComponentC { get; private set; }

    public Mediator()
    {
        ComponentA = new ComponentA(this);
        ComponentB = new ComponentB(this);
        ComponentC = new ComponentC(this);
    }

    public void Notify(Component sender, string eventName)
    {
        if (sender.Equals(ComponentA))
        {
            switch (eventName)
            {
                case "Received":
                    ComponentB.Activate();
                    ComponentC.NotifyReceived();
                    break;
                case "Reset":
                    ComponentB.Deactivate();
                    ComponentC.NotifyReset();
                    break;
            }
        }
    }
}
