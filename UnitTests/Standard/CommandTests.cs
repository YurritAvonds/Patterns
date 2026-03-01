using FluentAssertions;
using Patterns.Standard.Command;

namespace UnitTests.Standard;

internal class CommandTests
{
    [Test]
    public void IncrementInteger()
    {
        // Arrange
        var receiver = new Receiver();
        var invoker = new Invoker();
        var command = new IncrementIntegerCommand(receiver);

        // Act
        invoker.SetCommand(command);
        invoker.ExecuteCommand();

        // Assert
        receiver.GetIntegerValue().Should().Be(101);
    }

    [Test]
    public void DecrementInteger()
    {
        // Arrange
        var receiver = new Receiver();
        var invoker = new Invoker();
        var command = new DecrementIntegerCommand(receiver);

        // Act
        invoker.SetCommand(command);
        invoker.ExecuteCommand();

        // Assert
        receiver.GetIntegerValue().Should().Be(99);
    }

    [Test]
    public void ToggleBoolean()
    {
        // Arrange
        var receiver = new Receiver();
        var invoker = new Invoker();
        var incrementCommand = new ToggleBooleanCommand(receiver);

        // Act
        invoker.SetCommand(incrementCommand);
        invoker.ExecuteCommand();

        // Assert
        receiver.GetBooleanValue().Should().BeFalse();
    }
}
