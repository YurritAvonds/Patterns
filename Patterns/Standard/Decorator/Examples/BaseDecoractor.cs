namespace Patterns.Standard.Decorator.Examples;

public class BaseDecoractor(IComponent component) : IComponent
{
    private readonly IComponent _component = component;

    public virtual string Execute()
    {
        return _component.Execute();
    }
}
