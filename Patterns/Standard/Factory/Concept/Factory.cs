using Patterns.Standard.Factory.Examples;

namespace Patterns.Standard.Factory.Concept;

/// <summary>
/// (Optional) factory base class that contains shared methods common to all factory types.
/// </summary>
public abstract class Factory : IFactory
{
    public IBaseType this[int index] => Objects[index];

    protected List<IBaseType> Objects { get; private set; } = [];

    /// <summary>
    /// Adds an object to the factory so that it can produce this object later.
    /// </summary>
    /// <param name="inputObject"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void AddObject(IBaseType inputObject)
    {
        if (inputObject == null)
        {
            throw new ArgumentNullException(nameof(inputObject), "Object is null in AddVariant method.");
        }

        Objects.Add(inputObject);
    }

    /// <summary>
    /// Produces an enumerator that iterates through the objects in the factory.
    /// </summary>
    /// <returns></returns>
    public IEnumerator<IBaseType> GetEnumerator()
    {
        foreach (var variant in Objects)
        {
            yield return variant;
        }
    }
}
