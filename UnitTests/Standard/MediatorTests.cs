using Patterns.Standard.Mediator.Examples;

namespace UnitTests.Standard;

internal class MediatorTests
{
    [Test]
    public void ReceiveMessage_ActivatesComponentBAndNotifiesComponentC()
    {
        // Arrange
        var mediator = new Mediator();

        // Act
        mediator.ComponentA.Receive("Hello, World!");

        // Assert
        mediator.ComponentB.IsActive.Should().BeTrue();
        mediator.ComponentC.Notification.Should().Be("Received a Message!");
    }

    [Test]
    public void Resete_DeactivatesComponentBAndNotifiesComponentC()
    {
        // Arrange
        var mediator = new Mediator();

        // Act
        mediator.ComponentA.Reset();

        // Assert
        mediator.ComponentB.IsActive.Should().BeFalse();
        mediator.ComponentC.Notification.Should().Be("Reset the message queue.");
    }
}
