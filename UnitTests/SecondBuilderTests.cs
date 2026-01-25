using FluentAssertions;
using Patterns.InheritedBuilder.Second;
using System.Xml.Linq;

namespace UnitTests;

public class SecondBuilderTests
{
    [TestCase(-1)]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [Category("With")]
    public void WithId(int id)
    {
        // Arrange
        SecondBuilder<SecondObject> secondBuilder = new();

        // Act
        var secondObject = secondBuilder
            .WithId(id)
            .Build();

        // Assert
        secondObject.Id.Should().Be(id);
    }

    [TestCase("Test Name")]
    [TestCase("")]
    [TestCase(null)]
    [Category("With")]
    public void WithName(string? name)
    {
        // Arrange
        SecondBuilder<SecondObject> secondBuilder = new();

        // Act
        var secondObject = secondBuilder
            .WithName(name)
            .Build();

        // Assert
        secondObject.Name.Should().Be(name);
    }
}
