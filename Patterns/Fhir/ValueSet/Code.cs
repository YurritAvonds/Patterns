namespace Patterns.Fhir.ValueSet;

/// <summary>
/// Equivalent of the Coding in FHIR
/// https://www.hl7.org/fhir/R4/datatypes.html#Coding
/// </summary>
/// <param name="Value"></param>
/// <param name="Display"></param>
public record Code(string Value = "", string Display = "")
{
    public string? Value { get; set; } = Value;
    public string? Display { get; set; } = Display;
}
