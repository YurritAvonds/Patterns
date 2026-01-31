using FluentAssertions;
using Patterns.Singleton;

namespace UnitTests.Composite;

[TestFixture]
public class SingletonTests
{
    [Test]
    public void FirstMethod_ReturnsFirstProperty()
    {
        // Arrange
        Singleton.GetInstance().FirstProperty = 42;

        // Act
        Singleton.GetInstance().FirstProperty = 50;

        // Assert
        Assert.Equals(50, Singleton.GetInstance().FirstProperty);
    }
}
