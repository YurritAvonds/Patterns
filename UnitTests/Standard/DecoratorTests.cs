using Patterns.Standard.Decorator;

namespace UnitTests.Standard;

internal class DecoratorTests
{
    [Test]
    public void FirstDecorator()
    {
        // Arrange
        var component = new Component();
        var firstDecorator = new FirstDecorator(component);

        // Act
        var result = firstDecorator.Execute();

        // Assert
        result.Should().Be("<first>Component Content</first>");
    }

    [Test]
    public void SecondDecorator()
    {
        // Arrange
        var component = new Component();
        var secondDecorator = new SecondDecorator(component);

        // Act
        var result = secondDecorator.Execute();

        // Assert
        result.Should().Be("<second>Component Content</second>");
    }

    [Test]
    public void FirstAndSecondDecorator()
    {
        // Arrange
        var component = new Component();
        var firstDecorator = new FirstDecorator(component);
        var secondDecorator = new SecondDecorator(firstDecorator);

        // Act
        var result = secondDecorator.Execute();

        // Assert
        result.Should().Be("<second><first>Component Content</first></second>");
    }
}
