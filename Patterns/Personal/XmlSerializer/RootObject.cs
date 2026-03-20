namespace Patterns.Personal.XmlSerializer;

public class RootObject
{
    public LeafObject? LeafObject { get; set; }
    public string? RootString { get; set; }
    public int RootInteger { get; set; }
    public ICollection<NodeObject> NodeObjects { get; set; } = [];
}
