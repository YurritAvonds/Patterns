using FluentAssertions;
using Patterns.Standard.Factory;

namespace UnitTests.Standard;

public class FactoryTests
{
    [Test]
    [Category("Factory")]
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
    [Category("Factory")]
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

    [TestCase(FactoryType.One, false, false, true)]
    [TestCase(FactoryType.Two, true, true, false)]
    [Category("Abstract Factory")]
    public void Produce(FactoryType factoryType, bool expected1, bool expected2, bool expected3)
    {
        // Arrange
        var client = new AbstractFactoryClient();

        // Act
        var products = client.Produce(factoryType).ToList();

        // Assert
        products[0].Method().Should().Be(expected1);
        products[1].Method().Should().Be(expected2);
        products[2].Method().Should().Be(expected3);
    }
}
