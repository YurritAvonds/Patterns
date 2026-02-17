using FluentAssertions;
using Patterns.Personal.EmptyChecker;

namespace UnitTests.Personal.EmptyCheckerTests;

internal class EmptyCheckerTests
{
    [Test]
    public void Parent_Empty()
    {
        // Arrange
        var emptyChecker = new NullOrEmptyChecker();
        var parent = new Parent(emptyChecker);
        
        // Act
        bool result = parent.IsEmpty();

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void Child_Empty()
    {
        // Arrange
        var emptyChecker = new NullOrEmptyChecker();
        var child = new Child(emptyChecker);

        // Act
        bool result = child.IsEmpty();

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void Parent_NonEmptyString()
    {
        // Arrange
        var emptyChecker = new NullOrEmptyChecker();
        var parent = new Parent(emptyChecker)
        {
            ParentString = "Non-empty string"
        };

        // Act
        bool result = parent.IsEmpty();

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public void Child_NonEmptyString()
    {
        // Arrange
        var emptyChecker = new NullOrEmptyChecker();
        var child = new Child(emptyChecker)
        {
            ChildString = "Non-empty string"
        };

        // Act
        bool result = child.IsEmpty();

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public void Child_NonEmptyParentString()
    {
        // Arrange
        var emptyChecker = new NullOrEmptyChecker();
        var child = new Child(emptyChecker)
        {
            ParentString = "Non-empty string"
        };

        // Act
        bool result = child.IsEmpty();

        // Assert
        result.Should().BeFalse();
    }
}
