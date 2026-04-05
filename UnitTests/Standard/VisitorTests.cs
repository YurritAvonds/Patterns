using Patterns.Standard.Visitor;
using Patterns.Standard.Visitor.Examples;

namespace UnitTests.Standard;

internal class VisitorTests
{
    [Test]
    public void Visitor_ShouldCollectResults_WhenVisitingVariants()
    {
        // Arrange
        var variants = new List<IVisitable>
        {
            new VisitableOne(),
            new VisitableTwo()
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
