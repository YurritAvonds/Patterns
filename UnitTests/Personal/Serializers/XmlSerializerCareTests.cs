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
            CollectionSerializationMode.SingleObjectInEmptyCollection
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
        patientName.HasSingleEmptyElement("Use");
        patientName.HasSingleEmptyElement("Text");
        patientName.HasSingleEmptyElement("Family");
        patientName.HasSingle("Given").HasSingleEmptyElement("String");
        patientName.HasSingle("Prefix").HasSingleEmptyElement("String");
        patientName.HasSingle("Suffix").HasSingleEmptyElement("String");
        patientName.HasSingleEmptyElement("PeriodStart");
        patientName.HasSingleEmptyElement("PeriodEnd");
        patientName.HasSingleEmptyElement("FullName"); // TODO do not serialize getter only properties?

        var patientAddress = patient.HasSingle("Addresses").HasSingle("Address");
        patientAddress.HasSingleEmptyElement("Country");
        patientAddress.HasSingleEmptyElement("City");
        patientAddress.HasSingleEmptyElement("ZipCode");
        patientAddress.HasSingleEmptyElement("Street");
        patientAddress.HasSingleEmptyElement("StreetNumber");

        var practitioner = doc.HasSingle("Practitioner");

        practitioner.HasEmptyElement("Role");

        var practitionerName = practitioner.HasSingle("Names").HasSingle("HumanName");
        practitionerName.HasSingleEmptyElement("Use");
        practitionerName.HasSingleEmptyElement("Text");
        practitionerName.HasSingleEmptyElement("Family");
        practitionerName.HasSingle("Given").HasSingleEmptyElement("String");
        practitionerName.HasSingle("Prefix").HasSingleEmptyElement("String");
        practitionerName.HasSingle("Suffix").HasSingleEmptyElement("String");
        practitionerName.HasSingleEmptyElement("PeriodStart");
        practitionerName.HasSingleEmptyElement("PeriodEnd");
        practitionerName.HasSingleEmptyElement("FullName"); // TODO do not serialize getter only properties?

        var practitionerAddress = practitioner.HasSingle("Addresses").HasSingle("Address");
        practitionerAddress.HasSingleEmptyElement("Country");
        practitionerAddress.HasSingleEmptyElement("City");
        practitionerAddress.HasSingleEmptyElement("ZipCode");
        practitionerAddress.HasSingleEmptyElement("Street");
        practitionerAddress.HasSingleEmptyElement("StreetNumber");
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
        patientName.HasSingleEmptyElement("Use");
        patientName.HasSingleEmptyElement("Text");
        patientName.HasSingleElementWithValue("Family", "Bergman");
        patientName.HasSingle("Given").HasElementsWithValues("String", new[] { "Ernst", "Ingmar" });
        patientName.HasSingle("Prefix").HasSingleElementWithValue("String", "Mr");
        patientName.HasSingle("Suffix").HasSingleEmptyElement("String");
        patientName.HasSingleEmptyElement("PeriodStart");
        patientName.HasSingleEmptyElement("PeriodEnd");
        //patientName.HasSingleEmptyElement("FullName"); // TODO do not serialize getter only properties?

        var patientAddress = patient.HasSingle("Addresses").HasSingle("Address");
        patientAddress.HasSingleElementWithValue("Country", "Sweden");
        patientAddress.HasSingleElementWithValue("City", "Faro");
        patientAddress.HasSingleElementWithValue("ZipCode", "12345");
        patientAddress.HasSingleElementWithValue("Street", "Main Street");
        patientAddress.HasSingleElementWithValue("StreetNumber", "123");

        var practitioner = doc.HasSingle("Practitioner");

        practitioner.HasEmptyElement("Role");

        var practitionerName = practitioner.HasSingle("Names").HasSingle("HumanName");
        practitionerName.HasSingleEmptyElement("Use");
        practitionerName.HasSingleEmptyElement("Text");
        practitionerName.HasSingleEmptyElement("Family");
        practitionerName.HasSingle("Given").HasSingleEmptyElement("String");
        practitionerName.HasSingle("Prefix").HasSingleEmptyElement("String");
        practitionerName.HasSingle("Suffix").HasSingleEmptyElement("String");
        practitionerName.HasSingleEmptyElement("PeriodStart");
        practitionerName.HasSingleEmptyElement("PeriodEnd");
        //practitionerName.HasSingleEmptyElement("FullName"); // TODO do not serialize getter only properties?

        var practitionerAddress = practitioner.HasSingle("Addresses").HasSingle("Address");
        practitionerAddress.HasSingleEmptyElement("Country");
        practitionerAddress.HasSingleEmptyElement("City");
        practitionerAddress.HasSingleEmptyElement("ZipCode");
        practitionerAddress.HasSingleEmptyElement("Street");
        practitionerAddress.HasSingleEmptyElement("StreetNumber");
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
                        Family = "Bergman"
                    }
                ],
                Addresses = [
                    new()
                    {
                        Country = "Sweden",
                        City = "Faro",
                        Street = "Main Street",
                        StreetNumber = 123,
                        ZipCode = 12345
                    }
                ],
                Status = Status.Default
            },
        };
    }
}
