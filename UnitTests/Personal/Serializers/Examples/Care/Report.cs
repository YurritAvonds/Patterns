namespace UnitTests.Personal.Serializers.Examples.Care;

internal class Report
{
    public Patient? Patient { get; set; }
    public Practitioner? Practitioner { get; set; }
    public ICollection<Observation> Observations { get; set; } = [];
}
