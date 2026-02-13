namespace Patterns.Visitor;

internal class Client
{
    public void Run()
    {
        List<IBase> variants =
        [
            new VariantOne(),
            new VariantTwo()
        ];

        IVisitor visitor = new Visitor();
        foreach (var variant in variants)
        {
            variant.Accept(visitor);
        }
    }
}
