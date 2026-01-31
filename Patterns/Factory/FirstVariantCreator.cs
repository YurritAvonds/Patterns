namespace Patterns.Factory;

public class FirstVariantFactory : VariantsFactory
{
	readonly List<FirstVariant> variants = [];

	public FirstVariantFactory()
	{
		AddVariant(new FirstVariant(8.5, 10));
		AddVariant(new FirstVariant(10.0, 12));
		AddVariant(new FirstVariant(12.3, 14));
    }

	public override FirstVariant this[int index]
	{
		get { return variants[index]; }
	}
}
