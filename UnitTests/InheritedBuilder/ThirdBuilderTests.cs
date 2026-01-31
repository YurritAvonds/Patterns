using FluentAssertions;
using Patterns.InheritedBuilder.Second;
using Patterns.InheritedBuilder.Third;

namespace UnitTests.InheritedBuilder;

public class ThirdBuilderTests
{
    [TestCase(-1)]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [Category("With")]
    public void WithId(int id)
    {
        // Arrange
        ThirdBuilder thirdBuilder = new();

        // Act
        var thirdObject = thirdBuilder
            .WithId(id)
            .Build();

        // Assert
        thirdObject.Id.Should().Be(id);
    }

    [TestCase("Test Name")]
    [TestCase("")]
    [TestCase(null)]
    [Category("With")]
    public void WithName(string? name)
    {
        // Arrange
        ThirdBuilder thirdBuilder = new();

        // Act
        var thirdObject = thirdBuilder
            .WithName(name)
            .Build();

        // Assert
        thirdObject.Name.Should().Be(name);
    }

    [TestCase(true)]
    [TestCase(false)]
    [Category("With")]
    public void WithIsEmployed(bool isEmployed)
    {
        // Arrange
        ThirdBuilder thirdBuilder = new();

        // Act
        var thirdObject = thirdBuilder
            .WithIsEmployed(isEmployed)
            .Build();

        // Assert
        thirdObject.IsEmployed.Should().Be(isEmployed);
    }

    [Test]
    public void FullObject()
    {
        // Arrange
        ThirdBuilder thirdBuilder = new();

        // Act
        var fullObject = thirdBuilder
            .WithId(10)
            .WithName("Full Object")
            .Build();

        // Assert
        fullObject.Name.Should().Be("Full Object");
        fullObject.Id.Should().Be(10);
    }

    [Test]
    [Category("General")]
    public void ModifyExisting()
    {
        // Arrange
        var firstObject = new ThirdBuilder()
            .WithId(9)
            .WithName("Original")
            .WithIsEmployed(false)
            .Build();

        // Act
        var secondObject = new ThirdBuilder()
            .WithExisting(firstObject)
            .WithIsEmployed(true)
            .Build();

        // Assert
        secondObject.Id.Should().Be(9);
        secondObject.Name.Should().Be("Original");
        secondObject.IsEmployed.Should().Be(true);
    }
}
