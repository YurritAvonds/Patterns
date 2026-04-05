namespace Patterns.Standard.Singleton.Examples;

public class ExampleSingleton() : Concept.Singleton<ExampleSingleton>
{
    public int FirstProperty { get; set; } = 0;
}
