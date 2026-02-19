using Patterns.Fhir.ValueSet;

namespace Patterns.Fhir.HumanName;

internal class HumanNameCodeSystems
{
    public static readonly CodeSystem NameUse = new(
    "http://hl7.org/fhir/name-use",
    "2.16.840.1.113883.4.642.4.66")
    {
        Codes = [
        new Code("usual", "Usual"),
        new Code("official", "Official"),
        new Code("temp", "Temp"),
        new Code("nickname", "Nickname"),
        new Code("anonymous", "Anonymous"),
        new Code("old", "Old"),
        new Code("maiden", "Maiden"),
    ]
    };
}
