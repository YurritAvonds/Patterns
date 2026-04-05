using Patterns.Standard.Strategy;

namespace UnitTests.Standard;

internal class StrategyClientTests
{
    [Test]
    public void TestFirstStrategyResults()
    {
        // Arrange
        var strategyClient = new StrategyClient(new FirstStrategy());

        // Act
        var firstResult = strategyClient.ExecuteFirstMethod(10, 5);
        var secondResult = strategyClient.ExecuteSecondMethod("Test1");

        // Assert
        firstResult.Should().Be(15);
        secondResult.Should().Be("First Strategy received parameter Test1.");
    }

    [Test]
    public void TestSecondStrategyResults()
    {
        // Arrange
        var strategyClient = new StrategyClient(new SecondStrategy());

        // Act
        var firstResult = strategyClient.ExecuteFirstMethod(10, 5);
        var secondResult = strategyClient.ExecuteSecondMethod("Test2");

        // Assert
        firstResult.Should().Be(50);
        secondResult.Should().Be("Second Strategy received parameter Test2.");
    }
}
