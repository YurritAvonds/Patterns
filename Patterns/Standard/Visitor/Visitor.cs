namespace Patterns.Visitor;

public class Visitor : IVisitor
{
    public List<string> Results { get; private set; } = [];

    public void Visit(VariantOne variant)
        => Results.Add(variant.SomeMethod("Hello from Visitor to VariantOne"));
    public void Visit(VariantTwo variant)
        => Results.Add(variant.SomeMethod("Hello from Visitor to VariantTwo"));
}
