using Patterns.Standard.Iterator.Examples;

namespace UnitTests.Standard;

internal class IteratorTests
{

    [Test]
    public void FilledCollection()
    {
        // Arrange
        var collection = new ConcreteCollection();
        collection.LevelOneItems.Add(new Item("Level 1 - Item 1"));
        collection.LevelOneItems.Add(new Item("Level 1 - Item 2"));
        collection.LevelTwoItems.Add(new Item("Level 2 - Item 1"));
        collection.LevelTwoItems.Add(new Item("Level 2 - Item 2"));
        collection.LevelThreeItems.Add(new Item("Level 3 - Item 1"));
        collection.LevelThreeItems.Add(new Item("Level 3 - Item 2"));
        var iterator = collection.GetIterator();

        // Act
        var results = new List<string>();
        while (iterator.HasMore())
        {
            results.Add(((Item)iterator.GetNext()).Name);
        }

        // Assert
        results.Should().SatisfyRespectively(
            item => item.Should().Be("Level 1 - Item 1"),
            item => item.Should().Be("Level 1 - Item 2"),
            item => item.Should().Be("Level 2 - Item 1"),
            item => item.Should().Be("Level 2 - Item 2"),
            item => item.Should().Be("Level 3 - Item 1"),
            item => item.Should().Be("Level 3 - Item 2")
        );
    }

    [Test]
    public void IncompleteCollection()
    {
        // Arrange
        var collection = new ConcreteCollection();
        collection.LevelOneItems.Add(new Item("Level 1 - Item 1"));
        collection.LevelOneItems.Add(new Item("Level 1 - Item 2"));
        collection.LevelThreeItems.Add(new Item("Level 3 - Item 1"));
        collection.LevelThreeItems.Add(new Item("Level 3 - Item 2"));
        var iterator = collection.GetIterator();

        // Act
        var results = new List<string>();
        while (iterator.HasMore())
        {
            results.Add(((Item)iterator.GetNext()).Name);
        }

        // Assert
        results.Should().SatisfyRespectively(
            item => item.Should().Be("Level 1 - Item 1"),
            item => item.Should().Be("Level 1 - Item 2"),
            item => item.Should().Be("Level 3 - Item 1"),
            item => item.Should().Be("Level 3 - Item 2")
        );
    }

    [Test]
    public void SingleItem_LevelOne()
    {
        // Arrange
        var collection = new ConcreteCollection();
        collection.LevelOneItems.Add(new Item("Level 1 - Item 1"));
        var iterator = collection.GetIterator();

        // Act
        var results = new List<string>();
        while (iterator.HasMore())
        {
            results.Add(((Item)iterator.GetNext()).Name);
        }

        // Assert
        results.Should().SatisfyRespectively(
            item => item.Should().Be("Level 1 - Item 1")
        );
    }

    [Test]
    public void SingleItem_LevelOtherThanOne()
    {
        // Arrange
        var collection = new ConcreteCollection();
        collection.LevelTwoItems.Add(new Item("Level 2 - Item 1"));
        var iterator = collection.GetIterator();

        // Act
        var results = new List<string>();
        while (iterator.HasMore())
        {
            results.Add(((Item)iterator.GetNext()).Name);
        }

        // Assert
        results.Should().SatisfyRespectively(
            item => item.Should().Be("Level 2 - Item 1")
        );
    }

    [Test]
    public void EmptyCollection()
    {
        // Arrange
        var collection = new ConcreteCollection();
        var iterator = collection.GetIterator();

        // Act
        var results = new List<string>();
        while (iterator.HasMore())
        {
            results.Add(((Item)iterator.GetNext()).Name);
        }

        // Assert
        results.Should().BeEmpty();
    }
}
