namespace UnitTests.Personal.Serializers.Examples;

/// <summary>
/// Example class with simple properties, complex objects and collections to be serialized.
/// When used in a hierarchy, this is neither the Root object, nor a Leaf object.
/// </summary>
public class Node
{
    public string? NodeString { get; set; }
    public Node? NodeObject { get; set; }
    public ICollection<Leaf>? NodeObjects { get; set; } = [];
}
