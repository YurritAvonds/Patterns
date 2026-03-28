using FluentAssertions;
using Patterns.Standard.TemplateMethod;

namespace UnitTests.Standard;

internal class TemplateMethodTests
{
    [Test]
    public void CallProcessor()
    {
        // Arrange
        var processor = new Processor();

        // Act
        var result = processor.Process("Hello World");

        // Assert
        result.Should().Be("*** DLROW OLLEH ***");
    }

    [Test]
    public void CallAlternateProcessor()
    {
        // Arrange
        var processor = new AlternateProcessor();

        // Act
        var result = processor.Process("Hello World");

        // Assert
        result.Should().Be("[dlroW olleH]");
    }
}
