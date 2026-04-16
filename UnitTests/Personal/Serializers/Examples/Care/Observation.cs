using Patterns.Fhir.ValueSet;

namespace UnitTests.Personal.Serializers.Examples.Care;

internal class Observation
{
    public Code? Code { get; set; }
    public string? Text { get; set; }
}
