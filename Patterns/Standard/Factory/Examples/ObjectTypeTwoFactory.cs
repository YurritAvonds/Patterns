namespace Patterns.Standard.Factory.Examples;

/// <summary>
/// Factory that produces objects of type two.
/// </summary>
public class ObjectTypeTwoFactory : Concept.Factory
{
    /// <summary>
    /// The constructor of the factory adds objects to the factory, so that it can "produce" them later.
    /// </summary>
    public ObjectTypeTwoFactory()
    {
        AddObject(new ObjectTypeTwo(5.5, "Gamma"));
        AddObject(new ObjectTypeTwo(5.2, "Beta"));
        AddObject(new ObjectTypeTwo(4.5, "Alpha"));
    }
}
