using Patterns.Fhir.ValueSet;
using Patterns.Personal.Serializers.Concept;
using Patterns.Personal.Serializers.Examples;
using System.Xml;
using System.Xml.Linq;
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
        AssertNameIsEmpty(patientName);
        var patientAddress = patient.HasSingle("Addresses").HasSingle("Address");
        AssertAddressIsEmpty(patientAddress);

        var practitioner = doc.HasSingle("Practitioner");
        practitioner.HasSingleEmptyElement("Role");
        var practitionerName = practitioner.HasSingle("Names").HasSingle("HumanName");
        AssertNameIsEmpty(practitionerName);
        var practitionerAddress = practitioner.HasSingle("Addresses").HasSingle("Address");
        AssertAddressIsEmpty(practitionerAddress);

        var observation = doc.HasSingle("Observations").HasSingle("Observation");
        observation.HasSingleEmptyElement("Text");
        var observationCode = observation.HasSingle("Code");
        observationCode.HasSingleEmptyElement("Value");
        observationCode.HasSingleEmptyElement("Display");
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
        AssertName(patientName, "official", "Official", "Mr Ernst Ingmar Bergman dir.", "Bergman",
            ["Ernst", "Ingmar"], "Mr", "dir.", "1918-07-14 12:13:14 +02:00", "2007-07-30 13:14:15 +02:00");
        var patientAddress = patient.HasSingle("Addresses").HasSingle("Address");
        AssertAddress(patientAddress, "Sweden", "Faro", "12345", "Main Street", "123");

        var practitioner = doc.HasSingle("Practitioner");
        practitioner.HasSingleElementWithValue("Role", "General Practitioner");
        var practitionerNames = practitioner.HasSingle("Names").HasMultiple("HumanName", 2);
        AssertName(practitionerNames[0], "official", "Official", "Ms Berit Elisabet Andersson act.", "Andersson",
            ["Berit", "Elisabet"], "Ms", "act.", "1935-11-11 14:15:16 +02:00", "2019-04-14 16:17:18 +02:00");
        AssertName(practitionerNames[1], "nickname", "Nickname", "Bibi", string.Empty,
            ["Bibi"], string.Empty, string.Empty, "1935-11-11 14:15:16 +02:00", "2019-04-14 16:17:18 +02:00");
        var practitionerAddress = practitioner.HasSingle("Addresses").HasSingle("Address");
        AssertAddress(practitionerAddress, "Sweden", "Stockholm", "44556", "Market Street", "456");

        var observation = doc.HasSingle("Observations").HasMultiple("Observation", 2);
        AssertObservation(observation[0], "Frontal Headache observed", "frontheadache", "Frontal Headache");
        AssertObservation(observation[1], "Mild Fever observed", "mildfever", "Mild Fever");
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

    private static void AssertNameIsEmpty(XElement? practitionerName)
    {
        var practitionerNameUse = practitionerName.HasSingle("Use");
        practitionerNameUse.HasSingleEmptyElement("Value");
        practitionerNameUse.HasSingleEmptyElement("Display");
        practitionerName.HasSingleEmptyElement("Text");
        practitionerName.HasSingleEmptyElement("Family");
        practitionerName.HasSingle("Given").HasSingleEmptyElement("String");
        practitionerName.HasSingle("Prefix").HasSingleEmptyElement("String");
        practitionerName.HasSingle("Suffix").HasSingleEmptyElement("String");
        practitionerName.HasSingleEmptyElement("PeriodStart");
        practitionerName.HasSingleEmptyElement("PeriodEnd");
        practitionerName.HasNoElement("FullName");
    }

    private static void AssertAddressIsEmpty(XElement? patientAddress)
    {
        patientAddress.HasSingleEmptyElement("Country");
        patientAddress.HasSingleEmptyElement("City");
        patientAddress.HasSingleEmptyElement("ZipCode");
        patientAddress.HasSingleEmptyElement("Street");
        patientAddress.HasSingleEmptyElement("StreetNumber");
    }

    private static void AssertObservation(XElement observation, string text, string code, string display)
    {
        observation.HasSingleElementWithValue("Text", text);
        var observationCode = observation.HasSingle("Code");
        observationCode.HasSingleElementWithValue("Value", code);
        observationCode.HasSingleElementWithValue("Display", display);
    }

    private static void AssertName(XElement? patientName, string useCode, string useDisplay, string text,
        string family, string[] given, string prefix, string suffix, string periodStart, string periodEnd)
    {
        patientName.HasSingle("Use").HasSingleElementWithValue("Value", useCode);
        patientName.HasSingle("Use").HasSingleElementWithValue("Display", useDisplay);
        patientName.HasSingleElementWithValue("Text", text);
        patientName.HasSingleElementWithValue("Family", family);
        patientName.HasSingle("Given").HasElementsWithValues("String", given);
        patientName.HasSingle("Prefix").HasSingleElementWithValue("String", prefix);
        patientName.HasSingle("Suffix").HasSingleElementWithValue("String", suffix);
        patientName.HasSingleElementWithValue("PeriodStart", periodStart);
        patientName.HasSingleElementWithValue("PeriodEnd", periodEnd);
        patientName.HasNoElement("FullName");
    }

    private static void AssertAddress(XElement? practitionerAddress, string country, string city,
        string zipCode, string street, string streetNumber)
    {
        practitionerAddress.HasSingleElementWithValue("Country", country);
        practitionerAddress.HasSingleElementWithValue("City", city);
        practitionerAddress.HasSingleElementWithValue("ZipCode", zipCode);
        practitionerAddress.HasSingleElementWithValue("Street", street);
        practitionerAddress.HasSingleElementWithValue("StreetNumber", streetNumber);
    }
}
