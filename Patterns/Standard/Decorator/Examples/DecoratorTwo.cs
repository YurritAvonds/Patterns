namespace Patterns.Standard.Decorator.Examples;

public class DecoratorTwo(IComponent component) : BaseDecoractor(component)
{
    public override string Execute() => $"<second>{base.Execute()}</second>";
}
