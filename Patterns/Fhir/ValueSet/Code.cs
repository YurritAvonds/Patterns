namespace Patterns.Fhir.ValueSet
{
    public record Code(string value, string display)
    {
        public string Value { get; private set; } = value;
        public string Display { get; private set; } = display;
    }
}
