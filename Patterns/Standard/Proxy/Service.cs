namespace Patterns.Standard.Proxy;

public class Service : IServiceInterface
{
    public string Operate(int integerValue)
    {
        return integerValue > 0
            ? "Data from the service."
            : "Cannot access service.";
    }
}
