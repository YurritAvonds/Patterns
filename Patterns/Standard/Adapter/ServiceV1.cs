namespace Patterns.Standard.Adapter;

/// <summary>
/// First version of an example service
/// </summary>
public class ServiceV1
{
    public string ServiceMethod(string data, bool convertToUpper)
        => convertToUpper
            ? data.ToUpper()
            : data;
}
