namespace Patterns.Factory;

	public class BooksPackage : IPackage
	{
		private List<Book> Books { get; init; }
		private Packaging Packaging {  get; init; }

		const double MaximumAcceptableWeight = 2.0;

		public BooksPackage() 
		{
			Books = [];
			Packaging = Packaging.None;
		}

		public BooksPackage(List<Book> books, Packaging packaging)
		{
			Books = books ?? [];
			Packaging = packaging;
		}

		public double TotalWeight => Books.Sum(b => b.Weight);

		/// <summary>
		/// Any package that has a box is acceptable.
		/// </summary>
		private bool HasAccetpablePackaging => Packaging.HasFlag(Packaging.Box);
		private bool HasAcceptableWeight => TotalWeight <= MaximumAcceptableWeight;
		public bool HasAcceptableContent() => HasAccetpablePackaging && HasAcceptableWeight;
	}
