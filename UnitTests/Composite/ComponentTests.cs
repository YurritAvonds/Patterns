using FluentAssertions;
using Patterns.Composite;

namespace UnitTests.Composite;

[TestFixture]
public class ComponentTests
{
    [Test]
    public void FirstMethod_ReturnsFirstProperty()
    {
        // Arrange
        double expected = 1.2345;
        var component = new Component(expected, "ignored");

        // Act
        double actual = component.FirstMethod();

        // Assert
        actual.Should().Be(expected);
    }

    [Test]
    public void SecondMethod_ReturnsSecondProperty()
    {
        // Arrange
        string expected = "hello world";
        var component = new Component(0.0, expected);

        // Act
        string actual = component.SecondMethod();

        // Assert
        actual.Should().Be(expected);
    }
}
