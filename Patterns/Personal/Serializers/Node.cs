namespace Patterns.Personal.Serializers;

public class Node
{
    public string? NodeString { get; set; }
    public Node? NodeObject { get; set; }
    public ICollection<Leaf>? NodeObjects { get; set; } = [];
}
