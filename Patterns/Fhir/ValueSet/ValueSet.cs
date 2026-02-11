namespace Patterns.Fhir.ValueSet;

public class ValueSet(string uri, string oid) : ISystem
{
    public string Uri { get; private set; } = uri;
    public string Oid { get; private set; } = oid;
    public CodeSystem[] Codes { get; set; } = [];

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
