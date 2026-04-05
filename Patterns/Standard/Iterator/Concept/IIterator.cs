namespace Patterns.Standard.Iterator.Concept;

public interface IIterator
{
    public IIteratebleCollectionItem GetNext();
    public bool HasMore();
}
