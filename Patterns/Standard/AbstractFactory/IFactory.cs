using Patterns.Standard.Factory;

namespace Patterns.Standard.AbstractFactory;

public interface IFactory
{
    IBaseType this[int index] { get; }
}