namespace Patterns.Standard.Visitor;

public interface IBase
{
    public void Accept(IVisitor visitor);

    public string SomeMethod(string input);
}
