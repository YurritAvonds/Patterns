namespace Patterns.Standard.Visitor.Examples;

public class VisitableTwo : IVisitable
{
    public void Accept(IVisitor visitor)
        => visitor.Visit(this);

    public string SomeMethod(string input)
        => $"VariantTwo: {input}";
}
