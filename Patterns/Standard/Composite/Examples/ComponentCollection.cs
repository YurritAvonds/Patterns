namespace Patterns.Standard.Composite.Examples;

public class ComponentCollection(double firstParameter, string secondParameter) : IComponent
{
    double FirstProperty { get; set; } = firstParameter;
    string SecondProperty { get; set; } = secondParameter;
    List<IComponent> Components { get; set; } = [];

    public void AddComponent(IComponent component)
    {
        Components.Add(component);
    }

    public double FirstMethod()
    {
        var total = FirstProperty;
        foreach (var component in Components)
        {
            total += component.FirstMethod();
        }
        return total;
    }

    public string SecondMethod()
    {
        var combined = SecondProperty;
        foreach (var component in Components)
        {
            combined = $"{combined}|{component.SecondMethod()}";
        }
        return combined;
    }
}
