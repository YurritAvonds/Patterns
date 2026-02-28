namespace Patterns.Standard.Adapter;

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
