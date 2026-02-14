using FluentAssertions;

namespace UnitTests.Standard.Proxy;

internal class ProxyTests
{
    [TestCase(-2, "Cannot access service.")]
    [TestCase(-1, "Access denied. Integer value must be even.")]
    [TestCase(0, "Cannot access service.")]
    [TestCase(1, "Access denied. Integer value must be even.")]
    [TestCase(2, "Data from the service.")]
    public void Operate(int integerValue, string expectedResult)
    {
        // Arrange
        Patterns.Standard.Proxy.Proxy service = new();

        // Act
        var result = service.Operate(integerValue);

        // Assert
        result.Should().Be(expectedResult);
    }
}
