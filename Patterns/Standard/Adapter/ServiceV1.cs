namespace Patterns.Standard.Adapter;

public class ServiceV1
{
    public string ServiceMethod(string data, bool convertToUpper)
        => convertToUpper
            ? data.ToUpper()
            : data;
}
