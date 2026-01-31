namespace Patterns.Factory;

public abstract class VariantsFactory
{
	readonly List<IBaseType> Variants;

	public VariantsFactory()
	{ 
		Variants = [];
	}
		
	public void AddVariant(IBaseType variant)
	{
		if (variant == null)
		{
			throw new ArgumentNullException(nameof(variant), "Variant is null in AddVariant method.");
		}
		else
		{
			Variants.Add(variant);
		}
	}

	public abstract IBaseType this[int variantNumber]
	{
		get;
	}

	public IEnumerator<IBaseType> GetEnumerator()
	{
		foreach (IBaseType variant in Variants)
			yield return variant;
	}
}
