namespace Patterns.Standard.Visitor.Examples;

public class Visitor : IVisitor
{
    public List<string> Results { get; private set; } = [];

    public void Visit(VisitableOne variant)
        => Results.Add(variant.SomeMethod("Hello from Visitor to VariantOne"));
    public void Visit(VisitableTwo variant)
        => Results.Add(variant.SomeMethod("Hello from Visitor to VariantTwo"));
}
