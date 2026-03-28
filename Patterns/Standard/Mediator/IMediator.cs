namespace Patterns.Standard.Mediator;

public interface IMediator
{
    public void Notify(Component sender, string eventName);
}
