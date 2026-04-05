namespace Patterns.Standard.Visitor.Examples;

public class VisitableOne : IVisitable
{
    public void Accept(IVisitor visitor)
        => visitor.Visit(this);

    public string SomeMethod(string input)
        => $"VariantOne: {input}";
}
