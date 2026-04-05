namespace Patterns.Standard.Decorator.Examples;

public class DecoratorOne(IComponent component) : BaseDecoractor(component)
{
    public override string Execute() => $"<first>{base.Execute()}</first>";
}
