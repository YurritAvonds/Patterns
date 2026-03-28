using FluentAssertions;
using Patterns.Standard.Factory;

namespace UnitTests.Standard;

public class FactoryTests
{
    [Test]
    public void ObjectTypeOneFactory()
    {
        // Arrange
        var factory = new ObjectTypeOneFactory();
        var results = new List<ObjectTypeOne>();

        // Act
        foreach (ObjectTypeOne item in factory)
        {
            results.Add(item);
        }

        // Assert
        results[0].CommonProperty.Should().Be(8.5);
        results[0].TypeOneProperty.Should().Be(10);
        results[1].CommonProperty.Should().Be(10.0);
        results[1].TypeOneProperty.Should().Be(12);
        results[2].CommonProperty.Should().Be(12.3);
        results[2].TypeOneProperty.Should().Be(14);
    }

    [Test]
    public void ObjectTypeTwoFactory()
    {
        // Arrange
        var factory = new ObjectTypeTwoFactory();
        var results = new List<ObjectTypeTwo>();

        // Act
        foreach (ObjectTypeTwo item in factory)
        {
            results.Add(item);
        }

        // Assert
        results[0].CommonProperty.Should().Be(5.5);
        results[0].TypeTwoProperty.Should().Be("Gamma");
        results[1].CommonProperty.Should().Be(5.2);
        results[1].TypeTwoProperty.Should().Be("Beta");
        results[2].CommonProperty.Should().Be(4.5);
        results[2].TypeTwoProperty.Should().Be("Alpha");
    }
}
