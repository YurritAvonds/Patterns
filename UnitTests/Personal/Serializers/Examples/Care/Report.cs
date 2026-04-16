namespace UnitTests.Personal.Serializers.Examples.Care;

internal class Report
{
    public Patient? Patient { get; set; } = new Patient(); // TODO can we avoid having to init here?
    public Practitioner? Practitioner { get; set; } = new Practitioner(); // TODO can we avoid having to init here?
    public ICollection<Observation> Observations { get; set; } = [];
}
