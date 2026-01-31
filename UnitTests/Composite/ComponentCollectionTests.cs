using FluentAssertions;
using Patterns.Composite;

namespace UnitTests.Composite;

[TestFixture]
internal class ComponentCollectionTests
{
    [Test]
    public void FirstMethod_ShouldReturnCollectionAndItemsPropertiesTotal_WhenCalled()
    {
        // Arrange
        var root = new ComponentCollection(10.0, "root");
        root.AddComponent(new Component(2.5, "child1"));
        root.AddComponent(new Component(3.5, "child2"));

        // Act
        var result = root.FirstMethod();

        // Assert
        result.Should().Be((double)(10.0 + 2.5 + 3.5));
    }

    [Test]
    public void SecondMethod_ShouldReturnCollectionAndItemsPropertiesConcatenated_WhenCalled()
    {
        // Arrange
        var root = new ComponentCollection(0.0, "root");
        root.AddComponent(new Component(0.0, "child1"));
        root.AddComponent(new Component(0.0, "child2"));

        // Act
        var result = root.SecondMethod();

        // Assert
        result.Should().Be((string?)"root|child1|child2");
    }
}
