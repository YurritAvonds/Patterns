namespace Patterns.Fhir.HumanName;

internal class HumanNameValueSets
{
    public static readonly ValueSet.ValueSet NameUse = new(
    "http://hl7.org/fhir/ValueSet/name-use",
    "2.16.840.1.113883.4.642.3.65")
    {
        Codes = [ HumanNameCodeSystems.NameUse ]
    };
}
