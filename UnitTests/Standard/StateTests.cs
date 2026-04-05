using Patterns.Standard.State.Examples;

namespace UnitTests.Standard;

internal class StateTests
{
    [Test]
    public void StateTransitions()
    {
        // Arrange
        var context = new ConcreteContext(new StateOne());

        // Act
        context.Continue();
        context.Continue();
        context.Continue();

        // Assert
        context.Results.Should().Equal("One", "Two", "Three");
    }
}
