namespace Patterns.Standard.Visitor.Examples;

internal class Client
{
    public void Run()
    {
        List<IVisitable> variants =
        [
            new VisitableOne(),
            new VisitableTwo()
        ];

        IVisitor visitor = new Visitor();
        foreach (var variant in variants)
        {
            variant.Accept(visitor);
        }
    }
}
