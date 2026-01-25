using FluentAssertions;
using Patterns.InheritedBuilder.First;

namespace UnitTests;

public class FirstBuilderTests
{
    [TestCase(-1)]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [Category("With")]
    public void WithId(int id)
    {
        // Arrange
        FirstBuilder<FirstObject> firstBuilder = new();

        // Act
        var firstObject = firstBuilder
            .WithId(id)
            .Build();

        // Assert
        firstObject.Id.Should().Be(id);
    }
}
