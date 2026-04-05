using Patterns.Standard.Singleton.Examples;

namespace UnitTests.Standard;

[TestFixture]
public class SingletonTests
{
    [Test]
    public void FirstMethod_ReturnsFirstProperty()
    {
        // Arrange
        ExampleSingleton.GetInstance().FirstProperty = 42;

        // Act
        ExampleSingleton.GetInstance().FirstProperty = 50;

        // Assert
        ExampleSingleton.GetInstance().FirstProperty.Should().Be(50);
    }
}
