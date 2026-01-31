namespace Patterns.Factory;

public class Book
{
	public int NumberOfPages {  get; set; }
	public double Weight { get; set; }
	public Book() 
	{
		NumberOfPages = 0;
		Weight = 0;
	}

	public Book(int numberOfPages, double weight)
	{
		NumberOfPages = numberOfPages;
		Weight = weight;
	}
}
