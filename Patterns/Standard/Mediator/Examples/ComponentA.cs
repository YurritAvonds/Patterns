using Patterns.Standard.Mediator.Concept;

namespace Patterns.Standard.Mediator.Examples;

public class ComponentA(IMediator mediator) : Component(mediator)
{
    public List<string> Messages { get; private set; } = [];

    public void Receive(string message)
    {
        Messages.Add(message);
        mediator.Notify(this, "Received");
    }

    public void Reset()
    {
        Messages.Clear();
        mediator.Notify(this, "Reset");
    }
}
