namespace Patterns.Visitor;

public interface IBase
{
    public void Accept(IVisitor visitor);

    public string SomeMethod(string input);
}
