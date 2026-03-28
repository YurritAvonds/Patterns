namespace Patterns.Standard.Mediator;

public class ComponentC(IMediator mediator) : Component(mediator)
{
    public string Notification { get; private set; } = string.Empty;

    public void NotifyReceived() => Notification = "Received a Message!";
    public void NotifyReset() => Notification = "Reset the message queue.";
}
