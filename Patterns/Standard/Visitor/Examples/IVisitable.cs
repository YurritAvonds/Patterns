namespace Patterns.Standard.Visitor.Examples;

public interface IVisitable
{
    public void Accept(IVisitor visitor);

    public string SomeMethod(string input);
}
