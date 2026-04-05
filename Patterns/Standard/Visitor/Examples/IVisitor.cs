namespace Patterns.Standard.Visitor.Examples;

public interface IVisitor
{
    void Visit(VisitableOne variant);
    void Visit(VisitableTwo variant);
}
