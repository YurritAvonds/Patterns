namespace UnitTests.Personal.Serializers.Examples.Abstract;

/// <summary>
/// Example top level class to be serialized, containing simple properties, complex objects and collections.
/// </summary>
public class Root
{
    public Leaf? RootObject { get; set; }
    public string? RootString { get; set; }
    public int? RootInteger { get; set; }
    public ICollection<Node>? RootObjects { get; set; } = [];
}
