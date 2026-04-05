using Patterns.Personal.ResultMultipleErrors.Examples;
using Errors = Patterns.Standard.Result.Errors;

namespace UnitTests.Personal;

internal class ResultVariantTests
{
    [TestCase(26)]
    [TestCase(50)]
    [TestCase(74)]
    public void Result_Success(int inputValue)
    {
        // Arrange

        // Act
        var result = OuterOperation.DoSomething(inputValue);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(inputValue);
        result.Errors.Should().BeEmpty();
    }

    [TestCase(-2)]
    [TestCase(-10)]
    public void Result_TooLow(int inputValue)
    {
        // Arrange

        // Act
        var result = OuterOperation.DoSomething(inputValue);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Value.Should().BeNull();
        result.Errors.Should().SatisfyRespectively(
            error => error.Should().Be(Errors.InputTooLow)
            );
    }

    [TestCase(-1)]
    [TestCase(-11)]
    public void Result_TooLow_And_Odd(int inputValue)
    {
        // Arrange

        // Act
        var result = OuterOperation.DoSomething(inputValue);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Value.Should().BeNull();
        result.Errors.Should().SatisfyRespectively(
            error => error.Should().Be(Errors.InputTooLow),
            error => error.Should().Be(Errors.OddNumber)
            );
    }

    [TestCase(102)]
    [TestCase(110)]
    public void Result_TooHigh(int inputValue)
    {
        // Arrange

        // Act
        var result = OuterOperation.DoSomething(inputValue);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Value.Should().BeNull();
        result.Errors.Should().SatisfyRespectively(
            error => error.Should().Be(Errors.InputTooHigh)
            );
    }

    [TestCase(101)]
    [TestCase(111)]
    public void Result_TooHigh_And_Odd(int inputValue)
    {
        // Arrange

        // Act
        var result = OuterOperation.DoSomething(inputValue);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Value.Should().BeNull();
        result.Errors.Should().SatisfyRespectively(
            error => error.Should().Be(Errors.InputTooHigh),
            error => error.Should().Be(Errors.OddNumber)
            );
    }

    [Test]
    public void Result_Null()
    {
        // Arrange

        // Act
        var result = OuterOperation.DoSomething(null);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Value.Should().BeNull();
        result.Errors.Should().SatisfyRespectively(
            error => error.Should().Be(Errors.InputNull)
        );
    }

    [TestCase(1)]
    [TestCase(99)]
    public void Result_Odd(int inputValue)
    {
        // Arrange

        // Act
        var result = OuterOperation.DoSomething(inputValue);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Value.Should().BeNull();
        result.Errors.Should().SatisfyRespectively(
            error => error.Should().Be(Errors.OddNumber)
        );
    }
}
