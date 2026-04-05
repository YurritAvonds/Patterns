namespace Patterns.Standard.Singleton.Concept;

public class Singleton<T> where T : class, new()
{
    private static T? instance;

    public static T GetInstance()
    {
        instance ??= new T();
        return instance;
    }
}