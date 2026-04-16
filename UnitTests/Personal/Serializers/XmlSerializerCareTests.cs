using Patterns.Fhir.ValueSet;
using Patterns.Personal.Serializers.Concept;
using Patterns.Personal.Serializers.Examples;
using System.Xml;
using UnitTests.Asserters;
using UnitTests.Personal.Serializers.Examples.Care;

namespace UnitTests.Personal.Serializers;

internal class XmlSerializerCareTests
{
    private readonly XmlSerializer xmlSerializer;

    public XmlSerializerCareTests()
    {
        xmlSerializer = new XmlSerializer(
            new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true,
                ConformanceLevel = ConformanceLevel.Auto
            },
            NullOrEmptyMode.SerializeEmptyExample
        );
    }

    [Test]
    [Category("Integration")]
    public void Serialize_EmptyReport()
    {
        // Arrange
        var report = new Report();

        // Act
        var result = xmlSerializer.Serialize(report);

        // Assert
        var doc = result.IsValidXmlNamed("Report");

        var patient = doc.HasSingle("Patient");

        patient.HasSingleEmptyElement("Status");

        var patientName = patient.HasSingle("Names").HasSingle("HumanName");
        patientName.HasSingle("Use").HasSingleEmptyElement("Value");
        patientName.HasSingle("Use").HasSingleEmptyElement("Display");
        patientName.HasSingleEmptyElement("Text");
        patientName.HasSingleEmptyElement("Family");
        patientName.HasSingle("Given").HasSingleEmptyElement("String");
        patientName.HasSingle("Prefix").HasSingleEmptyElement("String");
        patientName.HasSingle("Suffix").HasSingleEmptyElement("String");
        patientName.HasSingleEmptyElement("PeriodStart");
        patientName.HasSingleEmptyElement("PeriodEnd");
        patientName.HasNoElement("FullName");

        var patientAddress = patient.HasSingle("Addresses").HasSingle("Address");
        patientAddress.HasSingleEmptyElement("Country");
        patientAddress.HasSingleEmptyElement("City");
        patientAddress.HasSingleEmptyElement("ZipCode");
        patientAddress.HasSingleEmptyElement("Street");
        patientAddress.HasSingleEmptyElement("StreetNumber");

        var practitioner = doc.HasSingle("Practitioner");

        practitioner.HasEmptyElement("Role");

        var practitionerName = practitioner.HasSingle("Names").HasSingle("HumanName");
        practitionerName.HasSingle("Use").HasSingleEmptyElement("Value");
        practitionerName.HasSingle("Use").HasSingleEmptyElement("Display");
        practitionerName.HasSingleEmptyElement("Text");
        practitionerName.HasSingleEmptyElement("Family");
        practitionerName.HasSingle("Given").HasSingleEmptyElement("String");
        practitionerName.HasSingle("Prefix").HasSingleEmptyElement("String");
        practitionerName.HasSingle("Suffix").HasSingleEmptyElement("String");
        practitionerName.HasSingleEmptyElement("PeriodStart");
        practitionerName.HasSingleEmptyElement("PeriodEnd");
        practitionerName.HasNoElement("FullName");

        var practitionerAddress = practitioner.HasSingle("Addresses").HasSingle("Address");
        practitionerAddress.HasSingleEmptyElement("Country");
        practitionerAddress.HasSingleEmptyElement("City");
        practitionerAddress.HasSingleEmptyElement("ZipCode");
        practitionerAddress.HasSingleEmptyElement("Street");
        practitionerAddress.HasSingleEmptyElement("StreetNumber");

        var observation = doc.HasSingle("Observations").HasSingle("Observation");
        observation.HasSingle("Code").HasSingleEmptyElement("Value");
        observation.HasSingle("Code").HasSingleEmptyElement("Display");
        observation.HasSingleEmptyElement("Text");
    }

    [Test]
    [Category("Integration")]
    public void Serialize_FilledReport()
    {
        // Arrange
        var report = CreateExampleReport();

        // Act
        var result = xmlSerializer.Serialize(report);

        // Assert
        var doc = result.IsValidXmlNamed("Report");

        var patient = doc.HasSingle("Patient");

        patient.HasSingleElementWithValue("Status", "Default");

        var patientName = patient.HasSingle("Names").HasSingle("HumanName");
        patientName.HasSingle("Use").HasSingleElementWithValue("Value", "official");
        patientName.HasSingle("Use").HasSingleElementWithValue("Display", "Official");
        patientName.HasSingleElementWithValue("Text", "Mr Ernst Ingmar Bergman dir.");
        patientName.HasSingleElementWithValue("Family", "Bergman");
        patientName.HasSingle("Given").HasElementsWithValues("String", ["Ernst", "Ingmar"]);
        patientName.HasSingle("Prefix").HasSingleElementWithValue("String", "Mr");
        patientName.HasSingle("Suffix").HasSingleElementWithValue("String", "dir.");
        patientName.HasSingleElementWithValue("PeriodStart", "1918-07-14 12:13:14 +02:00");
        patientName.HasSingleElementWithValue("PeriodEnd", "2007-07-30 13:14:15 +02:00");
        patientName.HasNoElement("FullName");

        var patientAddress = patient.HasSingle("Addresses").HasSingle("Address");
        patientAddress.HasSingleElementWithValue("Country", "Sweden");
        patientAddress.HasSingleElementWithValue("City", "Faro");
        patientAddress.HasSingleElementWithValue("ZipCode", "12345");
        patientAddress.HasSingleElementWithValue("Street", "Main Street");
        patientAddress.HasSingleElementWithValue("StreetNumber", "123");

        var practitioner = doc.HasSingle("Practitioner");

        practitioner.HasElementValue("Role", "General Practitioner");

        var practitionerNames = practitioner.HasSingle("Names").HasMultiple("HumanName", 2);
        practitionerNames[0].HasSingle("Use").HasSingleElementWithValue("Value", "official");
        practitionerNames[0].HasSingle("Use").HasSingleElementWithValue("Display", "Official");
        practitionerNames[0].HasSingleElementWithValue("Text", "Ms Berit Elisabet Andersson act.");
        practitionerNames[0].HasSingleElementWithValue("Family", "Andersson");
        practitionerNames[0].HasSingle("Given").HasElementsWithValues("String", ["Berit", "Elisabet"]);
        practitionerNames[0].HasSingle("Prefix").HasSingleElementWithValue("String", "Ms");
        practitionerNames[0].HasSingle("Suffix").HasSingleElementWithValue("String", "act.");
        practitionerNames[0].HasSingleElementWithValue("PeriodStart", "1935-11-11 14:15:16 +02:00");
        practitionerNames[0].HasSingleElementWithValue("PeriodEnd", "2019-04-14 16:17:18 +02:00");
        practitionerNames[0].HasNoElement("FullName");

        practitionerNames[1].HasSingle("Use").HasSingleElementWithValue("Value", "nickname");
        practitionerNames[1].HasSingle("Use").HasSingleElementWithValue("Display", "Nickname");
        practitionerNames[1].HasSingleElementWithValue("Text", "Bibi");
        practitionerNames[1].HasSingleEmptyElement("Family");
        practitionerNames[1].HasSingle("Given").HasElementsWithValues("String", ["Bibi"]);
        practitionerNames[1].HasSingleEmptyElement("Prefix");
        practitionerNames[1].HasSingleEmptyElement("Suffix");
        practitionerNames[1].HasSingleElementWithValue("PeriodStart", "1935-11-11 14:15:16 +02:00");
        practitionerNames[1].HasSingleElementWithValue("PeriodEnd", "2019-04-14 16:17:18 +02:00");
        practitionerNames[1].HasNoElement("FullName");

        var practitionerAddress = practitioner.HasSingle("Addresses").HasSingle("Address");
        practitionerAddress.HasSingleElementWithValue("Country", "Sweden");
        practitionerAddress.HasSingleElementWithValue("City", "Stockholm");
        practitionerAddress.HasSingleElementWithValue("ZipCode", "44556");
        practitionerAddress.HasSingleElementWithValue("Street", "Market Street");
        practitionerAddress.HasSingleElementWithValue("StreetNumber", "456");

        var observation = doc.HasSingle("Observations").HasMultiple("Observation", 2);
        observation[0].HasSingle("Code").HasSingleElementWithValue("Value", "frontheadache");
        observation[0].HasSingle("Code").HasSingleElementWithValue("Display", "Frontal Headache");
        observation[0].HasSingleElementWithValue("Text", "Frontal Headache observed");
        observation[1].HasSingle("Code").HasSingleElementWithValue("Value", "mildfever");
        observation[1].HasSingle("Code").HasSingleElementWithValue("Display", "Mild Fever");
        observation[1].HasSingleElementWithValue("Text", "Mild Fever observed");
    }

    private static Report CreateExampleReport()
    {
        return new Report
        {
            Patient = new Patient
            {
                Names = [
                    new()
                    {
                        Prefix = ["Mr"],
                        Given = ["Ernst", "Ingmar"],
                        Family = "Bergman",
                        Use = new Code("official", "Official"),
                        PeriodStart = new DateTimeOffset(1918, 7, 14, 12, 13, 14, new TimeSpan(2,0,0)),
                        PeriodEnd = new DateTimeOffset(2007, 7, 30, 13, 14, 15, new TimeSpan(2,0,0)),
                        Suffix = ["dir."],
                        Text = "Mr Ernst Ingmar Bergman dir."
                    }
                ],
                Addresses = [
                    new()
                    {
                        Country = "Sweden",
                        City = "Faro",
                        Street = "Main Street",
                        StreetNumber = 123,
                        ZipCode = 12345,
                    }
                ],
                Status = Status.Default
            },
            Practitioner = new Practitioner
            {
                Names = [
                    new()
                    {
                        Prefix = ["Ms"],
                        Given = ["Berit", "Elisabet"],
                        Family = "Andersson",
                        Use = new Code("official", "Official"),
                        PeriodStart = new DateTimeOffset(1935, 11, 11, 14, 15, 16, new TimeSpan(2,0,0)),
                        PeriodEnd = new DateTimeOffset(2019, 4, 14, 16, 17, 18, new TimeSpan(2,0,0)),
                        Suffix = ["act."],
                        Text = "Ms Berit Elisabet Andersson act."
                    },
                    new()
                    {
                        Given = ["Bibi"],
                        Use = new Code("nickname", "Nickname"),
                        PeriodStart = new DateTimeOffset(1935, 11, 11, 14, 15, 16, new TimeSpan(2,0,0)),
                        PeriodEnd = new DateTimeOffset(2019, 4, 14, 16, 17, 18, new TimeSpan(2,0,0)),
                        Text = "Bibi"
                    }
                ],
                Addresses = [
                    new()
                    {
                        Country = "Sweden",
                        City = "Stockholm",
                        Street = "Market Street",
                        StreetNumber = 456,
                        ZipCode = 44556,
                    }
                ],
                Role = "General Practitioner"
            },
            Observations = [
                new()
                {
                    Code = new Code("frontheadache", "Frontal Headache"),
                    Text = "Frontal Headache observed"
                },
                new()
                {
                    Code = new Code("mildfever", "Mild Fever"),
                    Text = "Mild Fever observed"
                }
            ]
        };
    }
}
