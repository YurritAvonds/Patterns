namespace Patterns.Standard.Mediator.Concept;

public interface IMediator
{
    public void Notify(Component sender, string eventName);
}
