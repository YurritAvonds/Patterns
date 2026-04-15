namespace UnitTests.Personal.Serializers.Examples.Abstract;

/// <summary>
/// Example class with only simple properties to be serialized.
/// </summary>
public class Leaf
{
    public string? LeafString { get; set; }
    public int? LeafInteger { get; set; }
    public bool? LeafBoolean { get; set; }
}
