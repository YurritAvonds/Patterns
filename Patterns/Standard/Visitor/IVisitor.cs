namespace Patterns.Standard.Visitor;

public interface IVisitor
{
    void Visit(VariantOne variant);
    void Visit(VariantTwo variant);
}
