
using Patterns.Standard.AbstractFactory;

namespace Patterns.Standard.Factory;

public class SecondVariantFactory : VariantsFactory, IFactory
{
	public SecondVariantFactory()
	{
		AddVariant(new SecondVariant(5.5, "Gamma"));
		AddVariant(new SecondVariant(5.2, "Beta"));
		AddVariant(new SecondVariant(4.5, "Alpha"));
    }

	public override SecondVariant this[int index]
	{
		get { return (SecondVariant)Variants[index]; }
	}
}
