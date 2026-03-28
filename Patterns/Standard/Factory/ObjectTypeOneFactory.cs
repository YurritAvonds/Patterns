namespace Patterns.Standard.Factory;

/// <summary>
/// Factory that produces objects of type one.
/// </summary>
public class ObjectTypeOneFactory : Factory
{
    /// <summary>
    /// The constructor of the factory adds objects to the factory, so that it can "produce" them later.
    /// </summary>
    public ObjectTypeOneFactory()
    {
        AddObject(new ObjectTypeOne(8.5, 10));
        AddObject(new ObjectTypeOne(10.0, 12));
        AddObject(new ObjectTypeOne(12.3, 14));
    }
}
