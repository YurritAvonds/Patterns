namespace Patterns.Standard.Decorator;

public class FirstDecorator(IComponent component) : BaseDecoractor(component)
{
    public override string Execute() => $"<first>{base.Execute()}</first>";
}
