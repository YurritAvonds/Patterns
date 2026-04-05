using Patterns.Standard.Prototype.Examples;

namespace UnitTests.Standard;

internal class PrototypeTests
{
    [Test]
    public void CloneParent()
    {
        // Arrange
        var parent = new ParentProtoType("Hello World");

        // Act
        var clone = parent.Clone() as ParentProtoType;

        // Assert
        clone.Should().NotBeNull();
        clone.StringProperty.Should().Be(parent.StringProperty);
    }

    [Test]
    public void CloneChild()
    {
        // Arrange
        var child = new ChildPrototype("Hello World", 42);
        // Act
        var clone = child.Clone() as ChildPrototype;
        // Assert
        clone.Should().NotBeNull();
        clone.StringProperty.Should().Be(child.StringProperty);
        clone.IntegerProperty.Should().Be(child.IntegerProperty);
    }
}
