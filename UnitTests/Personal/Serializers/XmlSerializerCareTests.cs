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
            }
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
        var doc = XElement.Parse(result);
        doc.Name.LocalName.Should().Be("Report");
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
        var doc = XElement.Parse(result);
        doc.Name.LocalName.Should().Be("Report");

        // TODO what should collections of strings look like?
        // TODO ignore public getter only properties?

        doc.Element("Patient")?.Elements("Names")?.First().Element("Family")?.HasValue("Bergman");
        doc.Element("Patient")?.Elements("Names")?.First().Element("Given")?.Elements("String").ToList()[0].HasValue("Ernst");
        doc.Element("Patient")?.Elements("Names")?.First().Element("Given")?.Elements("String").ToList()[1].HasValue("Ingmar");
        doc.Element("Patient")?.Elements("Names")?.First().Elements("Prefix")?.Elements("String").ToList()[0].HasValue("Mr");
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
