using Patterns.Standard.Iterator.Concept;

namespace Patterns.Standard.Iterator.Examples;

internal class ConcreteIterator(ConcreteCollection collection) : IIterator
{
    private int levelOnePosition = 0;
    private int levelTwoPosition = 0;
    private int levelThreePosition = 0;

    public IIteratebleCollectionItem GetNext()
    {
        if (levelOnePosition < collection.LevelOneItems.Count)
        {
            var item = collection.LevelOneItems[levelOnePosition];
            levelOnePosition++;
            return item;
        }
        else if (levelTwoPosition < collection.LevelTwoItems.Count)
        {
            var item = collection.LevelTwoItems[levelTwoPosition];
            levelTwoPosition++;
            return item;
        }
        else if (levelThreePosition < collection.LevelThreeItems.Count)
        {
            var item = collection.LevelThreeItems[levelThreePosition];
            levelThreePosition++;
            return item;
        }
        else
        {
            throw new InvalidOperationException("No more items to iterate.");
        }
    }

    public bool HasMore()
    {
        return levelOnePosition < collection.LevelOneItems.Count ||
               levelTwoPosition < collection.LevelTwoItems.Count ||
               levelThreePosition < collection.LevelThreeItems.Count;
    }
}
