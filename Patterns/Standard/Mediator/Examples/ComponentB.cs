using Patterns.Standard.Mediator.Concept;

namespace Patterns.Standard.Mediator.Examples;

public class ComponentB(IMediator mediator) : Component(mediator)
{
    public bool IsActive { get; private set; } = false;

    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;
}
