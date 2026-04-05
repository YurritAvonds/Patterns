using Patterns.Standard.Result;

namespace UnitTests.Standard;

internal class ResultTests
{
    [TestCase(26)]
    [TestCase(50)]
    [TestCase(74)]
    public void Result_Success(int inputValue)
    {
        // Arrange
        var outerOperation = new OuterOperation();

        // Act
        var result = OuterOperation.DoSomething(inputValue);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(inputValue);
        result.Error.Should().BeNull();
    }

    [TestCase(-2)]
    [TestCase(-10)]
    public void Result_TooLow(int inputValue)
    {
        // Arrange
        var outerOperation = new OuterOperation();

        // Act
        var result = OuterOperation.DoSomething(inputValue);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Value.Should().BeNull();
        result.Error.Should().Be(Errors.InputTooLow);
    }

    [TestCase(102)]
    [TestCase(110)]
    public void Result_TooHigh(int inputValue)
    {
        // Arrange
        var outerOperation = new OuterOperation();

        // Act
        var result = OuterOperation.DoSomething(inputValue);

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
        var result = OuterOperation.DoSomething(null);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Value.Should().BeNull();
        result.Error.Should().Be(Errors.InputNull);
    }

    [TestCase(1)]
    [TestCase(99)]
    public void Result_Odd(int inputValue)
    {
        // Arrange
        var outerOperation = new OuterOperation();

        // Act
        var result = OuterOperation.DoSomething(inputValue);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Value.Should().BeNull();
        result.Error.Should().Be(Errors.OddNumber);
    }
}
