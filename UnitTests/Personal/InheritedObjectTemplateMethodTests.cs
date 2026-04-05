using Patterns.Personal.InheritedObjectTemplateMethod.Examples;

namespace UnitTests.Personal;

internal class InheritedObjectTemplateMethodTests
{
    [Test]
    public void Parent()
    {
        // Arrange
        var service = new ParentService<ParentObject>();
        var sourceObject = new ParentObject
        {
            StringProperty = "Test",
            IntegerProperty = 9
        };

        // Act
        var result = service.CreateResult(sourceObject);

        // Assert
        result.StringResult.Should().Be("TEST");
        result.DoubleResult.Should().Be(4.5);
    }

    [Test]
    [TestCase(true, "[Test]")]
    [TestCase(false, "")]
    public void Child(bool createString, string expectedString)
    {
        // Arrange
        var service = new ChildService<ChildObject>();
        var sourceObject = new ChildObject
        {
            StringProperty = "Test",
            IntegerProperty = 9,
            BooleanProperty = createString,
            DoubleProperty = 2.5
        };

        // Act
        var result = service.CreateResult(sourceObject);

        // Assert
        result.StringResult.Should().Be(expectedString);
        result.DoubleResult.Should().Be(22.5);
    }
}
