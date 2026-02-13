namespace Patterns.Composite;

public class ComponentCollection : IComponent
{
	double FirstProperty{ get; set; }
	string SecondProperty { get; set; }
	List<IComponent> Components { get; set; }

	public ComponentCollection(double firstParameter, string secondParameter)
	{ 
		FirstProperty = firstParameter;
		SecondProperty = secondParameter;
		Components = [];
	}

	public void AddComponent(IComponent component)
	{
		Components.Add(component);
	}

	public double FirstMethod()
	{
		double total = FirstProperty;
		foreach (IComponent component in Components)
		{
			total += component.FirstMethod();
		}
		return total;
	}

	public string SecondMethod()
	{
		string combined = SecondProperty;
		foreach (IComponent component in Components)
		{
			combined = $"{combined}|{component.SecondMethod()}";
		}
		return combined;
	}
}
