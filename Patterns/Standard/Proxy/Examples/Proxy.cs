namespace Patterns.Standard.Proxy.Examples;

public class Proxy : IServiceInterface
{
    public string Operate(int integerValue)
        => IsEven(integerValue)
            ? new Service().Operate(integerValue)
            : "Access denied. Integer value must be even.";

    private static bool IsEven(int integerValue)
        => integerValue % 2 == 0;
}
