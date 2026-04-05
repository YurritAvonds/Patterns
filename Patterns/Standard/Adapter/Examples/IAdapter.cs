namespace Patterns.Standard.Adapter.Examples;

/// <summary>
/// Example interface of an adapter, which defines the method(s) that the client code will interact with.
/// </summary>
public interface IAdapter
{
    public string AdapterMethod(string data);
}
