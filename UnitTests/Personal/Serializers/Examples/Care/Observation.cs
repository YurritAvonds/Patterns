using Patterns.Fhir.ValueSet;

namespace UnitTests.Personal.Serializers.Examples.Care;

internal class Observation
{
    public Code? Code { get; set; } = new Code(); // TODO avoid init?
    public string? Text { get; set; }
}
