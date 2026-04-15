namespace UnitTests.Personal.Serializers.Examples.Care;

internal class Report
{
    public Patient Patient { get; set; } = new Patient();
    public Practitioner Practitioner { get; set; } = new Practitioner();
}
