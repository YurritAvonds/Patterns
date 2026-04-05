using Patterns.Standard.Bridge;

namespace UnitTests.Standard;

internal class BridgeTests
{
    [Test]
    public void ImplementationOne_Increment()
    {
        // Arrange
        var abstraction = new Abstraction(new ImplementationOne());

        // Act
        abstraction.IncrementValue();

        // Assert
        abstraction.ReadValue().Should().Be(2);
    }

    [Test]
    public void ImplementationOne_Decrement()
    {
        // Arrange
        var abstraction = new Abstraction(new ImplementationOne());

        // Act
        abstraction.DecrementValue();

        // Assert
        abstraction.ReadValue().Should().Be(0);
    }

    [Test]
    public void ImplementationOne_Toggle()
    {
        // Arrange
        var abstraction = new Abstraction(new ImplementationOne());

        // Act
        abstraction.ToggleEnabled();

        // Assert
        abstraction.IsEnabled().Should().BeTrue();
    }

    [Test]
    public void ImplementationTwo_Increment()
    {
        // Arrange
        var abstraction = new Abstraction(new ImplementationTwo());

        // Act
        abstraction.IncrementValue();

        // Assert
        abstraction.ReadValue().Should().Be(101);
        abstraction.IsEnabled().Should().BeTrue();
    }

    [Test]
    public void ImplementationTwo_Decrement()
    {
        // Arrange
        var abstraction = new Abstraction(new ImplementationTwo());

        // Act
        abstraction.DecrementValue();

        // Assert
        abstraction.ReadValue().Should().Be(99);
        abstraction.IsEnabled().Should().BeFalse();
    }

    [Test]
    public void ImplementationTwo_Toggle()
    {
        // Arrange
        var abstraction = new Abstraction(new ImplementationTwo());

        // Act
        abstraction.ToggleEnabled();

        // Assert
        abstraction.ReadValue().Should().Be(99);
        abstraction.IsEnabled().Should().BeFalse();
    }
}
