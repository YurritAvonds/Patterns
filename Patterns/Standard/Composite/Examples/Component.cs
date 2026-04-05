namespace Patterns.Standard.Composite.Examples;

public class Component(double firstProperty, string secondProperty) : IComponent
{
    public double FirstMethod() => firstProperty;
    public string SecondMethod() => secondProperty;
}
