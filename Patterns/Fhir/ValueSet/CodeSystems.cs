namespace Patterns.Fhir.ValueSet;

public static class CodeSystems
{
    public static readonly CodeSystem TaskIntent = new(
        "http://hl7.org/fhir/task-intent",
        "2.16.840.1.113883.4.642.4.1241")
    {
        Codes = [
            "unknown"
        ]
    };

    public static readonly CodeSystem RequestIntent = new(
        "http://hl7.org/fhir/request-intent",
        "2.16.840.1.113883.4.642.4.114")
    {
        Codes = [
            "proposal",
            "plan",
            "order",
            "original-order",
            "reflex-order",
            "filler-oder",
            "instance-oder",
            "option"
        ]
    };
}
