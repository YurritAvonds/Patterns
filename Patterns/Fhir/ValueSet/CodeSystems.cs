namespace Patterns.Fhir.ValueSet;

public static class CodeSystems
{
    public static readonly CodeSystem TaskIntent = new(
        "http://hl7.org/fhir/task-intent",
        "2.16.840.1.113883.4.642.4.1241")
    {
        Codes = [
            new Code("unknown", "Unknown")
        ]
    };

    public static readonly CodeSystem RequestIntent = new(
        "http://hl7.org/fhir/request-intent",
        "2.16.840.1.113883.4.642.4.114")
    {
        Codes = [
            new Code("proposal", "Proposal"),
            new Code("plan", "Plan"),
            new Code("order", "Order"),
            new Code("original-order", "Original Order"),
            new Code("reflex-order", "Reflex Order"),
            new Code("filler-oder", "Filler Oder"),
            new Code("instance-oder", "Instance Oder"),
            new Code("option", "Option")
        ]
    };
}
