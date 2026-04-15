using Patterns.Fhir.HumanName;

namespace UnitTests.Personal.Serializers.Examples.Care;

internal class Person
{
    public ICollection<HumanName> Names { get; set; } = [];
    public ICollection<Address> Addresses { get; set; } = [];
}
