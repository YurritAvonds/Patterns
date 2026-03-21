using FluentAssertions;
using Patterns.Personal.XmlSerializer;
using System.Xml.Linq;

namespace UnitTests.Personal;

internal class XmlSerializerTests
{
    [Test]
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

        var leaf = doc.Element("RootObject");
        leaf.Should().NotBeNull();
        leaf.Value.Should().BeEmpty();

        var rootString = doc.Element("RootString");
        rootString.Should().NotBeNull();
        rootString.Value.Should().BeEmpty();

        var rootInteger = doc.Element("RootInteger");
        rootInteger.Should().NotBeNull();
        rootInteger.Value.Should().Be("0");

        var nodeObjects = doc.Element("RootObjects");
        nodeObjects.Should().NotBeNull();

        var nodes = nodeObjects!.Elements("Node").ToList();
        nodes.Should().HaveCount(1);

        var node = nodes[0];
        var nodeObjectString = node.Element("NodeString");
        nodeObjectString.Should().NotBeNull();
        nodeObjectString.Value.Should().BeEmpty();
        var nodeNodeObject = node.Element("NodeObject");
        nodeNodeObject.Should().NotBeNull();
        nodeNodeObject.Value.Should().BeEmpty();
        var subObjects = node.Element("NodeObjects");
        subObjects.Should().NotBeNull();
        subObjects.Elements().Should().BeEmpty();
    }

    [Test]
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
