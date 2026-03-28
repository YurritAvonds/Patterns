using Patterns.Standard.Factory;

namespace Patterns.Standard.AbstractFactory;

/// <summary>
/// The client determines which factory to use based on a setting.
/// </summary>
public class Client
{
    private IFactory? factory;

    public IEnumerable<IBaseType> Produce(FactoryType factoryType)
    {
        Setup(factoryType);
        return Produce();
    }

    private void Setup(FactoryType factoryType)
    {
        factory = factoryType switch
        {
            FactoryType.One => new ObjectTypeOneFactory(),
            FactoryType.Two => new ObjectTypeTwoFactory(),
            _ => throw new ArgumentException("Invalid system type"),
        };
    }

    private IEnumerable<IBaseType> Produce()
    {
        if (factory == null)
        {
            throw new InvalidOperationException("Factory not initialized");
        }

        foreach (var item in factory)
        {
            yield return item;
        }
    }
}
