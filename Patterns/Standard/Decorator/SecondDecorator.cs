namespace Patterns.Standard.Decorator;

public class SecondDecorator(IComponent component) : BaseDecoractor(component)
{
    public override string Execute() => $"<second>{base.Execute()}</second>";
}
