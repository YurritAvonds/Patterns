using Patterns.Standard.Proxy.Examples;

namespace UnitTests.Standard;

internal class ProxyTests
{
    [TestCase(-2, "Cannot access service.")]
    [TestCase(-1, "Access denied. Integer value must be even.")]
    [TestCase(0, "Cannot access service.")]
    [TestCase(1, "Access denied. Integer value must be even.")]
    [TestCase(2, "Data from the service.")]
    public void OperateProxy(int integerValue, string expectedResult)
    {
        // Arrange
        Proxy service = new();

        // Act
        var result = service.Operate(integerValue);

        // Assert
        result.Should().Be(expectedResult);
    }

    [TestCase(-2, "Cannot access service.")]
    [TestCase(-1, "Cannot access service.")]
    [TestCase(0, "Cannot access service.")]
    [TestCase(1, "Data from the service.")]
    [TestCase(2, "Data from the service.")]
    public void OperateService(int integerValue, string expectedResult)
    {
        // Arrange
        Service service = new();

        // Act
        var result = service.Operate(integerValue);

        // Assert
        result.Should().Be(expectedResult);
    }
}
