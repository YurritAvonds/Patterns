namespace Patterns.Fhir.ValueSet;

/// <summary>
/// Equivalent of a ValueSet in FHIR
/// https://hl7.org/fhir/R4/valueset.html
/// </summary>
/// <param name="uri"></param>
/// <param name="oid"></param>
public class ValueSet(string uri, string oid) : ISystem
{
    public string Uri { get; private set; } = uri;
    public string Oid { get; private set; } = oid;
    public CodeSystem[] Codes { get; set; } = [];

    /// <summary>
    /// Check whether the ValueSet contains a given code from a given system.
    /// </summary>
    /// <param name="system">URI of the system</param>
    /// <param name="value">Value of the code to be checked</param>
    /// <returns></returns>
    public bool ContainsCode(string system, string value)
    {
        var codeSystem = Codes.FirstOrDefault(codeSystem
            => codeSystem.Uri.Equals(system, StringComparison.OrdinalIgnoreCase));

        if (codeSystem == null)
        {
            return false;
        }

        var matchingCode = codeSystem.Codes.FirstOrDefault(code
            => code.Value.Equals(value, StringComparison.OrdinalIgnoreCase));

        return matchingCode != null;
    }
}
