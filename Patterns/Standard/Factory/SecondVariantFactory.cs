
namespace Patterns.Factory;

public class SecondVariantFactory : VariantsFactory
{
	readonly List<SecondVariant> secondVariantPackages = [];

	public SecondVariantFactory()
	{
		AddVariant(new SecondVariant(4.5, "Alpha"));
		AddVariant(new SecondVariant(5.0, "Beta"));
		AddVariant(new SecondVariant(5.5, "Gamma"));
    }

	public override SecondVariant this[int index]
	{
		get { return secondVariantPackages[index]; }
	}
}
