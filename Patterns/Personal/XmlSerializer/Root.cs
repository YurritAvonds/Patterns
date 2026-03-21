namespace Patterns.Personal.XmlSerializer;

public class Root
{
    public Leaf? RootObject { get; set; }
    public string? RootString { get; set; }
    public int RootInteger { get; set; }
    public ICollection<Node> RootObjects { get; set; } = [];
}
