using FluentAssertions;
using Patterns.Personal.XmlSerializer;
using System.Xml.Linq;

namespace UnitTests.Personal;

internal class XmlSerializerTests
{


    [Test]
    [Category("Integration")]
    public void Serialize_EmptyObject()
    {
        // Arrange
        var rootObject = new Root();
        rootObject.RootObjects.Add(new Node());
        var xmlSerializer = new XmlSerializer();

        // Act
        var result = xmlSerializer.Serialize(rootObject);

        // Assert
        var doc = XElement.Parse(result);
        doc.Name.LocalName.Should().Be("Root");

        doc.Element("RootObject").Should().NotBeNull();
        doc.Element("RootObject")?.Value.Should().BeEmpty();

        doc.Element("RootString").Should().NotBeNull();
        doc.Element("RootString")?.Value.Should().BeEmpty();

        doc.Element("RootInteger").Should().NotBeNull();
        doc.Element("RootInteger")?.Value.Should().Be("0");

        doc.Element("RootObjects").Should().NotBeNull();
        doc.Element("RootObjects")?.Elements("Node").ToList().Should().HaveCount(1);
        doc.Element("RootObjects")?.Elements("Node").ToList()[0].Element("NodeString").Should().NotBeNull();
        doc.Element("RootObjects")?.Elements("Node")?.ToList()[0].Element("NodeString")?.Value.Should().BeEmpty();
        doc.Element("RootObjects")?.Elements("Node").ToList()[0].Element("NodeObject").Should().NotBeNull();
        doc.Element("RootObjects")?.Elements("Node")?.ToList()[0].Element("NodeObject")?.Value.Should().BeEmpty();
        doc.Element("RootObjects")?.Elements("Node").ToList()[0].Element("NodeObjects").Should().NotBeNull();
        doc.Element("RootObjects")?.Elements("Node")?.ToList()[0].Element("NodeObjects")?.Elements().Should().BeEmpty();
    }

    [Test]
    [Category("Integration")]
    public void Serialize_FilledObject()
    {
        // Arrange
        var rootObject = new Root
        {
            RootString = "L1_String",
            RootInteger = 1,
            RootObject = new Leaf
            {
                LeafString = "L2_String",
                LeafInteger = 2,
                LeafBoolean = true
            }
        };
        rootObject.RootObjects.Add(new Node()
        {
            NodeString = "L1_String",
            NodeObject = new Node()
            {
                NodeString = "L2_String",
                NodeObjects = [
                    new()
                    {
                        LeafString = "L2_Coll_Obj",
                        LeafInteger = 2,
                        LeafBoolean = false
                    }
                ]
            },
            NodeObjects = [
                new()
                {
                    LeafString = "L1_Coll_Obj",
                    LeafInteger = 1,
                    LeafBoolean = false
                }
            ]
        });
        var xmlSerializer = new XmlSerializer();

        // Act
        var result = xmlSerializer.Serialize(rootObject);

        // Assert
        var doc = XElement.Parse(result);
        doc.Name.LocalName.Should().Be("Root");

        doc.Element("RootString")?.Value.Should().Be("L1_String");
        doc.Element("RootInteger")?.Value.Should().Be("1");

        doc.Element("RootObject")?.Element("LeafString")?.Value.Should().Be("L2_String");
        doc.Element("RootObject")?.Element("LeafInteger")?.Value.Should().Be("2");
        doc.Element("RootObject")?.Element("LeafBoolean")?.Value.Should().Be("True");

        doc.Element("RootObjects")?.Element("NodeObject")?.Element("NodeString")?.Value.Should().Be("L1_String");
        doc.Element("RootObjects")?.Element("NodeObject")?.Element("NodeObject")?.Element("NodeString")?.Value.Should().Be("L2_String");
        doc.Element("RootObjects")?.Element("NodeObject")?.Element("NodeObject")?.Element("NodeObjects")?.Element("LeafObject")?.Element("LeafString")?.Value.Should().Be("L2_Coll_Obj");
        doc.Element("RootObjects")?.Element("NodeObject")?.Element("NodeObject")?.Element("NodeObjects")?.Element("LeafObject")?.Element("LeafInteger")?.Value.Should().Be("2");
        doc.Element("RootObjects")?.Element("NodeObject")?.Element("NodeObject")?.Element("NodeObjects")?.Element("LeafObject")?.Element("LeafBoolean")?.Value.Should().Be("False");

        doc.Element("RootObjects")?.Element("NodeObject")?.Element("NodeObjects")?.Element("LeafObject")?.Element("LeafString")?.Value.Should().Be("L1_Coll_Obj");
        doc.Element("RootObjects")?.Element("NodeObject")?.Element("NodeObjects")?.Element("LeafObject")?.Element("LeafInteger")?.Value.Should().Be("1");
        doc.Element("RootObjects")?.Element("NodeObject")?.Element("NodeObjects")?.Element("LeafObject")?.Element("LeafBoolean")?.Value.Should().Be("False");
    }
}
