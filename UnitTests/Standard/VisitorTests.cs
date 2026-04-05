using Patterns.Standard.Visitor;

namespace UnitTests.Standard;

internal class VisitorTests
{
    [Test]
    public void Visitor_ShouldCollectResults_WhenVisitingVariants()
    {
        // Arrange
        var variants = new List<IBase>
        {
            new VariantOne(),
            new VariantTwo()
        };
        var visitor = new Visitor();

        // Act
        foreach (var variant in variants)
        {
            variant.Accept(visitor);
        }

        // Assert
        visitor.Results.Should().BeEquivalentTo(new List<string>
        {
            "VariantOne: Hello from Visitor to VariantOne",
            "VariantTwo: Hello from Visitor to VariantTwo"
        });
    }
}
