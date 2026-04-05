using Patterns.Standard.Adapter.Examples;

namespace UnitTests.Standard;

internal class AdapterTests
{
    [Test]
    public void AdapterV1Test()
    {
        // Arrange
        var adapter = new AdapterV1();
        var client = new Client(adapter);

        // Act
        var result = client.ClientMethod("Test");

        // Assert
        result.Should().Be("TEST");
    }

    [Test]
    public void AdapterV2Test()
    {
        // Arrange
        var adapter = new AdapterV2();
        var client = new Client(adapter);

        // Act
        var result = client.ClientMethod("Test");

        // Assert
        result.Should().Be("TEST");
    }
}
