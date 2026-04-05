using Patterns.Standard.TemplateMethod;

namespace UnitTests.Standard;

internal class TemplateMethodTests
{
    [Test]
    public void CallProcessor()
    {
        // Arrange
        var processor = new Service();

        // Act
        var result = processor.Process("Hello World");

        // Assert
        result.Should().Be("*** DLROW OLLEH ***");
    }

    [Test]
    public void CallAlternateProcessor()
    {
        // Arrange
        var processor = new ServiceVariant();

        // Act
        var result = processor.Process("Hello World");

        // Assert
        result.Should().Be("[dlroW olleH]");
    }
}
