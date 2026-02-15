using FluentAssertions;
using Patterns.Standard.AbstractFactory;

namespace UnitTests.Standard.AbstractFactory;

internal class AbstractFactoryTests
{
    [TestCase(1, false, false, true)]
    [TestCase(2, true, true, false)]
    public void Produce(int systemType, bool expected1, bool expected2, bool expected3)
    {
        // Arrange
        var client = new Client();

        // Act
        client.Main(systemType);

        // Assert
        client.Results[0].SharedMethod().Should().Be(expected1);
        client.Results[1].SharedMethod().Should().Be(expected2);
        client.Results[2].SharedMethod().Should().Be(expected3);
    }
}
