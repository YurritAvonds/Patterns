using FluentAssertions;
using Patterns.InheritedBuilder.Second;
using Patterns.InheritedBuilder.Third;

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
        SecondBuilder secondBuilder = new();

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
        SecondBuilder secondBuilder = new();

        // Act
        var secondObject = secondBuilder
            .WithName(name)
            .Build();

        // Assert
        secondObject.Name.Should().Be(name);
    }

    [Test]
    public void FullObject()
    {
        // Arrange
        ThirdBuilder thirdBuilder = new();

        // Act
        var thirdObject = thirdBuilder
            .WithId(10)
            .WithName("Full Object")
            .WithIsEmployed(true)
            .Build();

        // Assert
        thirdObject.IsEmployed.Should().Be(true);
        thirdObject.Name.Should().Be("Full Object");
        thirdObject.Id.Should().Be(10);
    }
}
