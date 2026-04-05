using Patterns.Standard.Memento;

namespace UnitTests.Standard;

internal class MementoTests
{
    [Test]
    public void UpdateState()
    {
        // Arrange
        var originator = new Originator();
        var client = new Client(originator);

        // Act
        client.SetString("First state");
        client.SetInteger(42);
        client.SetString("Second state");
        client.SetInteger(100);

        // Assert
        originator.StateString.Should().Be("Second state");
        originator.StateInteger.Should().Be(100);
    }

    [Test]
    public void UndoState()
    {
        // Arrange
        var originator = new Originator();
        var client = new Client(originator);

        // Act
        client.SetString("First state");
        client.SetInteger(42);
        client.SetString("Second state");
        client.SetInteger(100);
        client.Undo();

        // Assert
        originator.StateString.Should().Be("Second state");
        originator.StateInteger.Should().Be(42);
    }

    [Test]
    public void UndoMultiple()
    {
        // Arrange
        var originator = new Originator();
        var client = new Client(originator);

        // Act
        client.SetString("First state");
        client.SetInteger(42);
        client.SetString("Second state");
        client.SetInteger(100);
        client.Undo();
        client.Undo();

        // Assert
        originator.StateString.Should().Be("First state");
        originator.StateInteger.Should().Be(42);
    }

    [Test]
    public void UndoAll()
    {
        // Arrange
        var originator = new Originator();
        var client = new Client(originator);

        // Act
        client.SetString("First state");
        client.SetInteger(42);
        client.SetString("Second state");
        client.SetInteger(100);
        client.Undo();
        client.Undo();
        client.Undo();
        client.Undo();

        // Assert
        originator.StateString.Should().Be(string.Empty);
        originator.StateInteger.Should().Be(0);
    }

    [Test]
    public void UndoBeyondHistory()
    {
        // Arrange
        var originator = new Originator();
        var client = new Client(originator);

        // Act
        client.SetString("First state");
        client.SetInteger(42);
        client.SetString("Second state");
        client.SetInteger(100);
        client.Undo();
        client.Undo();
        client.Undo();
        client.Undo();
        client.Undo();

        // Assert
        originator.StateString.Should().Be(string.Empty);
        originator.StateInteger.Should().Be(0);
    }
}
