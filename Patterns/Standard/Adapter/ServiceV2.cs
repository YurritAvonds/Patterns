namespace Patterns.Standard.Adapter;

/// <summary>
/// Second improved version of an example service, where the method(s) have a different signature.
/// </summary>
public class ServiceV2
{
    public enum CaseConversion
    {
        None,
        Upper,
        Lower
    }

    public string ServiceMethod(string data, CaseConversion caseConversion)
        => caseConversion switch
        {
            CaseConversion.None => data,
            CaseConversion.Upper => data.ToUpper(),
            CaseConversion.Lower => data.ToLower(),
            _ => throw new ArgumentException($"Unknown value {caseConversion} for {nameof(caseConversion)}")
        };
}
