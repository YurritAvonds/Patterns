namespace Patterns.Standard.Adapter;

/// <summary>
/// Adapter class that wraps the first version of the service and adapts it to the adapter interface.
/// </summary>
public class AdapterV1 : IAdapter
{
    ServiceV1 WrappedService { get; } = new ServiceV1();

    public string AdapterMethod(string data)
        => WrappedService.ServiceMethod(data, convertToUpper: true);
}
