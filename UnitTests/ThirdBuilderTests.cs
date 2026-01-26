using FluentAssertions;
using Patterns.InheritedBuilder.Third;

namespace UnitTests;

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
}
