namespace Patterns.Standard.Proxy;

public class Proxy : IServiceInterface
{
    public string Operate(int integerValue)
    {
        if (IsEven(integerValue))
        {
            return new Service().Operate(integerValue);
        }
        else
        {
            return "Access denied. Integer value must be even.";
        }
    }

    public bool IsEven(int integerValue)
    {
        return integerValue % 2 == 0;
    }
}
