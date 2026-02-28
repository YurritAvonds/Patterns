namespace Patterns.Standard.Visitor;

public class VariantOne : IBase
{
    public void Accept(IVisitor visitor)
        => visitor.Visit(this);

    public string SomeMethod(string input)
        => $"VariantOne: {input}";
}
