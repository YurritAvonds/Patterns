namespace UnitTests.Standard;

[TestFixture]
public class SingletonTests
{
    [Test]
    public void FirstMethod_ReturnsFirstProperty()
    {
        // Arrange
        Patterns.Standard.Singleton.Singleton.GetInstance().FirstProperty = 42;

        // Act
        Patterns.Standard.Singleton.Singleton.GetInstance().FirstProperty = 50;

        // Assert
        Patterns.Standard.Singleton.Singleton.GetInstance().FirstProperty.Should().Be(50);
    }
}
