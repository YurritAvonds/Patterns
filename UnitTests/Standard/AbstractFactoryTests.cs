using FluentAssertions;
using Patterns.Standard.AbstractFactory;

namespace UnitTests.Standard;

internal class AbstractFactoryTests
{
    [TestCase(FactoryType.One, false, false, true)]
    [TestCase(FactoryType.Two, true, true, false)]
    public void Produce(FactoryType factoryType, bool expected1, bool expected2, bool expected3)
    {
        // Arrange
        var client = new Client();

        // Act
        var products = client.Produce(factoryType).ToList();

        // Assert
        products[0].Method().Should().Be(expected1);
        products[1].Method().Should().Be(expected2);
        products[2].Method().Should().Be(expected3);
    }
}
