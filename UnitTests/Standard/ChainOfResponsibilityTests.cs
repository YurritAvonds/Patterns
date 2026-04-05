using Patterns.Standard.ChainOfResponsibility.Examples;

namespace UnitTests.Standard;

internal class ChainOfResponsibilityTests
{
    [Test]
    public void Chain_ShouldReturnContextWithBothChecksTrue_WhenIntegerAndStringAreValid()
    {
        // Arrange
        var integerHandler = new HandleIntegerAndContinueHandler(null);
        var stringHandler = new HandleStringAndContinueHandler(integerHandler);
        var request = new Request(
            IntegerValue: 5,
            StringValue: "This is a valid string.");
        var context = new Context();

        // Act
        stringHandler.Handle(request, context);

        // Assert
        context.HasValidString.Should().BeTrue();
        context.HasValidInteger.Should().BeTrue();
    }

    [Test]
    public void Chain_ShouldReturnContextWithOnlyIntegerCheckTrue_WhenStringIsInvalid()
    {
        // Arrange
        var integerHandler = new HandleIntegerAndContinueHandler(null);
        var stringHandler = new HandleStringAndContinueHandler(integerHandler);
        var request = new Request(
            IntegerValue: 5,
            StringValue: "invalid");
        var context = new Context();

        // Act
        stringHandler.Handle(request, context);

        // Assert
        context.HasValidString.Should().BeFalse();
        context.HasValidInteger.Should().BeTrue();
    }

    [Test]
    public void Chain_ShouldReturnContextWithIntegerCheckFalse_WhenIntegerIsInvalid()
    {
        // Arrange
        var integerHandler = new HandleIntegerAndContinueHandler(null);
        var stringHandler = new HandleStringAndContinueHandler(integerHandler);
        var request = new Request(
            IntegerValue: -10,
            StringValue: "This is a valid string.");
        var context = new Context();

        // Act
        stringHandler.Handle(request, context);

        // Assert
        context.HasValidString.Should().BeTrue();
        context.HasValidInteger.Should().BeFalse();
    }

    [Test]
    public void Chain_ShouldStopEarly_WhenStringCheckFails()
    {
        // Arrange
        var integerHandler = new HandleIntegerAndContinueHandler(null);
        var stringHandler = new HandleStringAndStopHandler(integerHandler);
        var request = new Request(
            IntegerValue: 5,
            StringValue: "invalid");
        var context = new Context();

        // Act
        stringHandler.Handle(request, context);

        // Assert
        context.HasValidString.Should().BeFalse();
        context.HasValidInteger.Should().BeNull();
    }
}
