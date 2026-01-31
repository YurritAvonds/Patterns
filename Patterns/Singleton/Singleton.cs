namespace Patterns.Singleton;

public class Singleton
{
	public int FirstProperty { get; set; }

	private static Singleton? instance;

	private Singleton()
	{
		FirstProperty = 0;
	}

	public static Singleton GetInstance()
	{
		instance ??= new Singleton();

		return instance;
	}
}
