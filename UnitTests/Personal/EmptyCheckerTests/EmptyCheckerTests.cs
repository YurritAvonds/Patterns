using FluentAssertions;
using Patterns.Personal.EmptyChecker;

namespace UnitTests.Personal.EmptyCheckerTests;

internal class EmptyCheckerTests
{
    [Test]
    [Category("Empty")]
    public void Parent_Empty()
    {
        // Arrange
        var emptyChecker = new NullOrEmptyChecker();
        var parent = new Parent(emptyChecker);

        // Act
        var result = parent.IsEmpty();

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    [Category("Empty")]
    public void Child_Empty()
    {
        // Arrange
        var emptyChecker = new NullOrEmptyChecker();
        var child = new Child(emptyChecker);

        // Act
        var result = child.IsEmpty();

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    [Category("Empty")]
    public void Parent_EmptyWithInitializedCollection()
    {
        // Arrange
        var emptyChecker = new NullOrEmptyChecker();
        var parent = new Parent(emptyChecker)
        {
            ParentCollection = []
        };

        // Act
        var result = parent.IsEmpty();

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    [Category("Empty")]
    public void Child_EmptyWithInitializedCollection()
    {
        // Arrange
        var emptyChecker = new NullOrEmptyChecker();
        var child = new Child(emptyChecker)
        {
            ChildCollection = []
        };

        // Act
        var result = child.IsEmpty();

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    [Category("Empty")]
    public void Child_EmptyWithInitializedParentCollection()
    {
        // Arrange
        var emptyChecker = new NullOrEmptyChecker();
        var child = new Child(emptyChecker)
        {
            ParentCollection = []
        };

        // Act
        var result = child.IsEmpty();

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    [Category("Not Empty")]
    public void Parent_NonEmptyString()
    {
        // Arrange
        var emptyChecker = new NullOrEmptyChecker();
        var parent = new Parent(emptyChecker)
        {
            ParentString = "Non-empty string"
        };

        // Act
        var result = parent.IsEmpty();

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    [Category("Not Empty")]
    public void Child_NonEmptyString()
    {
        // Arrange
        var emptyChecker = new NullOrEmptyChecker();
        var child = new Child(emptyChecker)
        {
            ChildString = "Non-empty string"
        };

        // Act
        var result = child.IsEmpty();

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    [Category("Not Empty")]
    public void Child_NonEmptyParentString()
    {
        // Arrange
        var emptyChecker = new NullOrEmptyChecker();
        var child = new Child(emptyChecker)
        {
            ParentString = "Non-empty string"
        };

        // Act
        var result = child.IsEmpty();

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    [Category("Not Empty")]
    public void Parent_NonEmptyCollection()
    {
        // Arrange
        var emptyChecker = new NullOrEmptyChecker();
        var parent = new Parent(emptyChecker)
        {
            ParentCollection = ["Item 1", "Item 2"]
        };

        // Act
        var result = parent.IsEmpty();

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    [Category("Not Empty")]
    public void Child_NonEmptyCollection()
    {
        // Arrange
        var emptyChecker = new NullOrEmptyChecker();
        var child = new Child(emptyChecker)
        {
            ChildCollection = ["Item 1", "Item 2"]
        };

        // Act
        var result = child.IsEmpty();

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    [Category("Not Empty")]
    public void Child_NonEmptyParentCollection()
    {
        // Arrange
        var emptyChecker = new NullOrEmptyChecker();
        var child = new Child(emptyChecker)
        {
            ParentCollection = ["Item 1", "Item 2"]
        };

        // Act
        var result = child.IsEmpty();

        // Assert
        result.Should().BeFalse();
    }
}
