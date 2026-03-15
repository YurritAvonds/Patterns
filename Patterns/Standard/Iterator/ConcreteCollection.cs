namespace Patterns.Standard.Iterator;

/// <summary>
/// An example collection to illustrate the pattern. The way the items are stored can be anything,
/// but the way the collection and iterator are related will always be the same.
/// </summary>
public class ConcreteCollection : IIterableCollection
{
    public IList<Item> LevelOneItems { get; } = [];
    public IList<Item> LevelTwoItems { get; } = [];
    public IList<Item> LevelThreeItems { get; } = [];

    public IIterator GetIterator() => new ConcreteIterator(this);
}
