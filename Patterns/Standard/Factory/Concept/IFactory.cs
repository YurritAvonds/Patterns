using Patterns.Standard.Factory.Examples;

namespace Patterns.Standard.Factory.Concept;

/// <summary>
/// By adding this interface, the client can interact with the factory without needing to know the specific type
/// of the factory. This allows for greater flexibility and decoupling between the client and the factory implementations.
/// </summary>
public interface IFactory
{
    /// <summary>
    /// Allows access to a specific object in the factory by index. This can be cast to the actual type in
    /// the implementation.
    /// </summary>
    /// <param name="index">Index of the object based on the order in which it was added to the factory.</param>
    /// <returns>The object with the specified index.</returns>
    IBaseType this[int index] { get; }
    public IEnumerator<IBaseType> GetEnumerator();
}