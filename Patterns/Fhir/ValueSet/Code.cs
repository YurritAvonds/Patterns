namespace Patterns.Fhir.ValueSet;

/// <summary>
/// Equivalent of the Coding in FHIR
/// https://www.hl7.org/fhir/R4/datatypes.html#Coding
/// </summary>
/// <param name="Value"></param>
/// <param name="Display"></param>
public record Code
{
    public Code()
    {
    }

    public Code(string value, string display)
    {
        Value = value;
        Display = display;
    }

    public string? Value { get; set; }
    public string? Display { get; set; }
}
