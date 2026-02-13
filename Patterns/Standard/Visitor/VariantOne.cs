namespace Patterns.Visitor;

public class VariantOne : IBase
{
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    public string SomeMethod(string input)
    {
        return $"VariantOne: {input}";
    }
}
