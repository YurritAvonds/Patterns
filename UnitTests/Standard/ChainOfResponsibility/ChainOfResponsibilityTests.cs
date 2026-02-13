using FluentAssertions;
using Patterns.Standard.ChainOfResponsibility;

namespace UnitTests.Standard.ChainOfResponsibility
{
    internal class ChainOfResponsibilityTests
    {
        [Test]
        public void Chain_ShouldReturnContextWithBothChecksTrue_WhenIntegerAndStringAreValid()
        {
            // Arrange
            var integerHandler = new IntegerHandler(null);
            var stringHandler = new StringContinueHandler(integerHandler);
            var request = new Request ( 
                IntegerValue: 5,
                StringValue: "This is a valid string." );
            var context = new Context();

            // Act
            integerHandler.Handle(request, context);
            // Assert
            context.HasValidString.Should().BeTrue();
            context.HasValidInteger.Should().BeTrue();
        }
    }
}
