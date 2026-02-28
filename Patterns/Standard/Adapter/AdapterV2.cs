namespace Patterns.Standard.Adapter;

public class AdapterV2 : IAdapter
{
    ServiceV2 WrappedService { get; } = new ServiceV2();

    public string AdapterMethod(string data)
        => WrappedService.ServiceMethod(data, ServiceV2.CaseConversion.Upper);
}
