using Patterns.Standard.Observer;

namespace UnitTests.Standard;

internal class ObserverTests
{
    [Test]
    public void ReceiveMessage_NotifiesListeners()
    {
        // Arrange
        var service = new Service();
        var listenerOne = new ListenerOne();
        var listenerTwo = new ListenerTwo();
        service.Subscribe(listenerOne);
        service.Subscribe(listenerTwo);

        // Act
        service.Receive("Hello, World!");

        // Assert
        listenerOne.Counter.Should().Be(13);
        listenerTwo.MessageStore.Count.Should().Be(1);
        listenerTwo.MessageStore.Should().Contain("Hello, World!");
    }
}
