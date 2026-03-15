namespace Patterns.Standard.Iterator;

public interface IIterator
{
    public Item GetNext();
    public bool HasMore();
}
