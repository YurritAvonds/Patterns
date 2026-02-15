using FluentAssertions;
using Patterns.Standard.State;

namespace UnitTests.Standard;

internal class StateTests
{
    [Test]
    public void StateTransitions()
    {
        // Arrange
        var stateOne = new StateOne();
        var context = new Context(stateOne);
        stateOne.SetContext(context);

        // Act
        var stringResult = "";
        stringResult += context.GetString();
        stringResult += context.GetString();
        stringResult += context.GetString();

        // Assert
        stringResult.Should().Be("OneTwoThree");
    }
}
