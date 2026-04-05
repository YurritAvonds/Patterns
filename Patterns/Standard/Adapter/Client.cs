namespace Patterns.Standard.Adapter;

/// <summary>
/// The client interacts with the interface of the adapter, so that new versions of the adapter
/// can be plugged in without making changes to the client code.
/// </summary>
/// <param name="adapter"></param>
public class Client(IAdapter adapter)
{
    public string ClientMethod(string data)
    {
        return adapter.AdapterMethod(data);
    }
}
