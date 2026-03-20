namespace Patterns.Personal.XmlSerializer;

public class NodeObject
{
    public string? NodeObjectString { get; set; }
    public NodeObject? NodeNodeObject { get; set; }
    public ICollection<LeafObject> SubObjects { get; set; } = [];
}
