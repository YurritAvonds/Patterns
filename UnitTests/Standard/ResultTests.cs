using FluentAssertions;
using Patterns.Standard.Result;

namespace UnitTests.Standard;

internal class ResultTests
{
    [TestCase(25)]
    [TestCase(50)]
    [TestCase(75)]
    public void Result_Success(int inputValue)
    {
        // Arrange
        var outerOperation = new OuterOperation();

        // Act
        var result = outerOperation.DoSomething(inputValue);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(inputValue);
        result.Error.Should().BeNull();
    }

    [TestCase(-1)]
    [TestCase(24)]
    public void Result_TooLow(int inputValue)
    {
        // Arrange
        var outerOperation = new OuterOperation();

        // Act
        var result = outerOperation.DoSomething(inputValue);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Value.Should().BeNull();
        result.Error.Should().Be(Errors.InputTooLow);
    }

    [TestCase(76)]
    [TestCase(101)]
    public void Result_TooHigh(int inputValue)
    {
        // Arrange
        var outerOperation = new OuterOperation();

        // Act
        var result = outerOperation.DoSomething(inputValue);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Value.Should().BeNull();
        result.Error.Should().Be(Errors.InputTooHigh);
    }

    [Test]
    public void Result_Null()
    {
        // Arrange
        var outerOperation = new OuterOperation();

        // Act
        var result = outerOperation.DoSomething(null);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Value.Should().BeNull();
        result.Error.Should().Be(Errors.InputNull);
    }
}
