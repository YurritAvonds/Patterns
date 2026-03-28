namespace Patterns.Standard.Mediator;

public class Component(IMediator mediator)
{
    protected readonly IMediator mediator = mediator;
}
