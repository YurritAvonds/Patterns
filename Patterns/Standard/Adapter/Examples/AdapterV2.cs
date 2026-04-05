namespace Patterns.Standard.Adapter.Examples;

/// <summary>
/// Adapter class that wraps the second, improved version of the service and adapts its changed method
/// signature(s) to the adapter interface. This way, clients that use the adapter interface do not have
/// to make changes to retain compatibility with the new version of the service.
/// </summary>
public class AdapterV2 : IAdapter
{
    ServiceV2 WrappedService { get; } = new ServiceV2();

    public string AdapterMethod(string data)
        => WrappedService.ServiceMethod(data, ServiceV2.CaseConversion.Upper);
}
