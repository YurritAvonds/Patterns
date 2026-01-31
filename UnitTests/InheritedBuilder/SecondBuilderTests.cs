using FluentAssertions;
using Patterns.InheritedBuilder.First;
using Patterns.InheritedBuilder.Second;
using Patterns.InheritedBuilder.Third;

namespace UnitTests.InheritedBuilder;

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

    [Test]
    [Category("General")]
    public void ModifyExisting()
    {
        // Arrange
        var firstObject = new SecondBuilder()
            .WithId(9)
            .WithName("Original")
            .Build();

        // Act
        var secondObject = new SecondBuilder()
            .WithExisting(firstObject)
            .WithName("Modified")
            .Build();

        // Assert
        secondObject.Id.Should().Be(9);
        secondObject.Name.Should().Be("Modified");
    }
}
