namespace Patterns.Standard.Adapter;

public class Client(IAdapter adapter)
{
    public string ClientMethod(string data)
    {
        return adapter.AdapterMethod(data);
    }
}
