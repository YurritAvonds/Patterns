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
