using FluentAssertions;
using Patterns.Standard.Proxy;

namespace UnitTests.Standard.Proxy;

internal class ServiceTests
{
    [TestCase(-2, "Cannot access service.")]
    [TestCase(-1, "Cannot access service.")]
    [TestCase(0, "Cannot access service.")]
    [TestCase(1, "Data from the service.")]
    [TestCase(2, "Data from the service.")]
    public void Operate(int integerValue, string expectedResult)
    {
        // Arrange
        Service service = new();
        
        // Act
        var result = service.Operate(integerValue);
        
        // Assert
        result.Should().Be(expectedResult);
    }
}
