
namespace Patterns.Factory;

public class FragilePackageCreator : PackageCreator
{
	readonly List<FragilePackage> fragilePackages = [];

	public FragilePackageCreator()
	{
		AddPackage(new FragilePackage("vase",1,Packaging.Box));
		AddPackage(new FragilePackage("wine glasses", 0.5, Packaging.BubbleWrapAndBox));
	}

	public override FragilePackage this[int index]
	{
		get { return fragilePackages[index]; }
	}
}
