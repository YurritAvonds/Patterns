namespace Patterns.Standard.Visitor;

public class VariantTwo : IBase
{
    public void Accept(IVisitor visitor)
        => visitor.Visit(this);

    public string SomeMethod(string input)
        => $"VariantTwo: {input}";
}
