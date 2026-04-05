namespace UnitTests.Standard;

public class BuilderTests
{
    [TestCase(-1)]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [Category("With")]
    public void WithIntegerValue(int integerValue)
    {
        // Arrange
        Patterns.Standard.Builder.Builder builder = new();

        // Act
        var resultingObject = builder
            .WithIntegerValue(integerValue)
            .Build();

        // Assert
        resultingObject.IntegerValue.Should().Be(integerValue);
    }

    [TestCase("Test String")]
    [TestCase("")]
    [Category("With")]
    public void WithStringValue(string stringValue)
    {
        // Arrange
        Patterns.Standard.Builder.Builder builder = new();

        // Act
        var resultingObject = builder
            .WithStringValue(stringValue)
            .Build();

        // Assert
        resultingObject.StringValue.Should().Be(stringValue);
    }

    [TestCase(true)]
    [TestCase(false)]
    [Category("With")]
    public void WithIsEmployed(bool booleanValue)
    {
        // Arrange
        Patterns.Standard.Builder.Builder builder = new();

        // Act
        var thirdObject = builder
            .WithBooleanValue(booleanValue)
            .Build();

        // Assert
        thirdObject.BooleanValue.Should().Be(booleanValue);
    }

    [Test]
    public void FullObject()
    {
        // Arrange
        Patterns.Standard.Builder.Builder builder = new();

        // Act
        var fullObject = builder
            .WithIntegerValue(10)
            .WithStringValue("Full Object")
            .WithBooleanValue(true)
            .Build();

        // Assert
        fullObject.StringValue.Should().Be("Full Object");
        fullObject.IntegerValue.Should().Be(10);
        fullObject.BooleanValue.Should().Be(true);
    }

    [Test]
    [Category("General")]
    public void ModifyExisting()
    {
        // Arrange
        var firstObject = new Patterns.Standard.Builder.Builder()
            .WithIntegerValue(9)
            .WithStringValue("Original")
            .WithBooleanValue(false)
            .Build();

        // Act
        var secondObject = new Patterns.Standard.Builder.Builder()
            .WithExisting(firstObject)
            .WithBooleanValue(true)
            .Build();

        // Assert
        secondObject.IntegerValue.Should().Be(9);
        secondObject.StringValue.Should().Be("Original");
        secondObject.BooleanValue.Should().Be(true);
    }
}
