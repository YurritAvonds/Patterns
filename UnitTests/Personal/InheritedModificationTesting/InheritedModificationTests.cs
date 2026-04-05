using FluentAssertions;
using UnitTests.Personal.InheritedModificationTesting.Examples;

namespace UnitTests.Personal.InheritedModificationTesting;

internal class InheritedModificationChildTests : InheritedModificationParentTests
{
    public InheritedModificationChildTests()
    {
        Creator = new Child();
    }

    [Test]
    public override void Execute_ShouldReturnResultObjectWithParentString_WhenCalled()
    {
        // Arrange

        // Act
        var result = Creator.Execute();
        // Assert
        result.StringProperty.Should().Be("Child");
    }
}

internal class InheritedModificationParentTests
{
    protected IParent Creator;

    public InheritedModificationParentTests()
    {
        Creator = new Parent();
    }

    [Test]
    public virtual void Execute_ShouldReturnResultObjectWithParentString_WhenCalled()
    {
        // Arrange
        // Act
        var result = Creator.Execute();
        // Assert
        result.StringProperty.Should().Be("Parent");
    }

    [Test]
    public void Execute_ShouldReturnResultObjectWithInt42_WhenCalled()
    {
        // Arrange
        // Act
        var result = Creator.Execute();
        // Assert
        result.IntProperty.Should().Be(42);
    }

    [Test]
    public void Execute_ShouldReturnResultObjectWithBoolTrue_WhenCalled()
    {
        // Arrange
        // Act
        var result = Creator.Execute();
        // Assert
        result.BoolProperty.Should().BeTrue();
    }

    [Test]
    public void Execute_ShouldReturnResultObjectWithDoublePi_WhenCalled()
    {
        // Arrange
        // Act
        var result = Creator.Execute();
        // Assert
        result.DoubleProperty.Should().Be(3.14);
    }
}
