namespace Patterns.Factory;

public abstract class PackageCreator
{
	readonly List<IPackage> Packages;

	public PackageCreator()
	{ 
		Packages = [];
	}
		
	public void AddPackage(IPackage package)
	{
		if (package == null)
		{
			throw new ArgumentNullException(nameof(package), "Package is null in AddPackage method.");
		}
		else
		{
			Packages.Add(package);
		}
	}

	public abstract IPackage this[int partNumber]
	{
		get;
	}

	public IEnumerator<IPackage> GetEnumerator()
	{
		foreach (IPackage package in Packages)
			yield return package;
	}
}
