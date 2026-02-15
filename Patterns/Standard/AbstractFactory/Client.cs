using Patterns.Standard.Factory;

namespace Patterns.Standard.AbstractFactory;

public class Client
{
    private IFactory? factory;
    public List<IBaseType> Results { get; private set; } = [];

    public void Main(int systemType)
    {
        Setup(systemType);
        Produce();
    }

    private void Produce()
    {
        if (factory == null)
        {
            throw new InvalidOperationException("Factory not initialized");
        }

        for (int i = 0; i < 3; i++)
        {
            Results.Add(factory[i]);
        }
    }

    private void Setup(int systemType)
    {
        if (systemType == 1)
        {
            factory = new FirstVariantFactory();
        }
        else if (systemType == 2)
        {
            factory = new SecondVariantFactory();
        }
        else
        {
            throw new ArgumentException("Invalid system type");
        }
    }
}
