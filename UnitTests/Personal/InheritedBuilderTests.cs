using FluentAssertions;
using Patterns.Personal.InheritedBuilder;

namespace UnitTests.Personal;

public class InheritedBuilderFirstBuilderTests
{
    [TestCase(-1)]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [Category("With")]
    public void WithId(int id)
    {
        // Arrange
        FirstBuilder firstBuilder = new();

        // Act
        var firstObject = firstBuilder
            .WithId(id)
            .Build();

        // Assert
        firstObject.Id.Should().Be(id);
    }

    [Test]
    [Category("General")]
    public void ModifyExisting()
    {
        // Arrange
        var firstObject = new FirstBuilder()
            .WithId(9)
            .Build();

        // Act
        var secondObject = new FirstBuilder()
            .WithExisting(firstObject)
            .WithId(10)
            .Build();

        // Assert
        secondObject.Id.Should().Be(10);
    }
}

public class InheritedBuilderSecondBuilderTests
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

public class InheritedBuilderThirdBuilderTests
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
