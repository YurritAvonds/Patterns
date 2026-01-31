namespace Patterns.Factory;

public class BookPackageCreator : PackageCreator
{
	readonly List<BooksPackage> bookPackages = [];

	public BookPackageCreator()
	{
		AddPackage(new BooksPackage(
					[
						new Book(150,0.4),
						new Book(226,0.8),
						new Book(1675,1.3),
					], Packaging.BubbleWrapAndBox));
		AddPackage(new BooksPackage(
					[
						new Book(67,0.2),
						new Book(156,0.7),
					], Packaging.BubbleWrap));
		AddPackage(new BooksPackage(
					[
						new Book(67,0.2),
						new Book(156,0.7),
					], Packaging.Box));
	}

	public override BooksPackage this[int index]
	{
		get { return bookPackages[index]; }
	}
}
