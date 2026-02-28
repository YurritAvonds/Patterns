namespace Patterns.Fhir.ValueSet;

public record Code(string Value, string Display)
{
    public string Value { get; private set; } = Value;
    public string Display { get; private set; } = Display;
}
