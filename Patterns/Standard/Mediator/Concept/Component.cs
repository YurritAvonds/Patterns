namespace Patterns.Standard.Mediator.Concept;

public class Component(IMediator mediator)
{
    protected readonly IMediator mediator = mediator;
}
