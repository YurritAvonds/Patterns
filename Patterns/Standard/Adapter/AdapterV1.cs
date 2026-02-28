namespace Patterns.Standard.Adapter;

public class AdapterV1 : IAdapter
{
    ServiceV1 WrappedService { get; } = new ServiceV1();

    public string AdapterMethod(string data)
        => WrappedService.ServiceMethod(data, convertToUpper: true);
}
