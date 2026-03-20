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
        var rootObject = new RootObject();
        rootObject.NodeObjects.Add(new NodeObject());
        var xmlSerializer = new XmlSerializer();

        // Act
        var result = xmlSerializer.Serialize(rootObject);

        // Assert
        var doc = XElement.Parse(result);
        doc.Name.LocalName.Should().Be("RootObject");

        var leaf = doc.Element("LeafObject");
        leaf.Should().NotBeNull();
        leaf!.Value.Should().BeEmpty();

        var rootString = doc.Element("RootString");
        rootString.Should().NotBeNull();
        rootString!.Value.Should().BeEmpty();

        var rootInteger = doc.Element("RootInteger");
        rootInteger.Should().NotBeNull();
        rootInteger!.Value.Should().Be("0");

        var nodeObjects = doc.Element("NodeObjects");
        nodeObjects.Should().NotBeNull();

        var nodes = nodeObjects!.Elements("NodeObject").ToList();
        nodes.Should().HaveCount(1);

        var node = nodes[0];
        var nodeObjectString = node.Element("NodeObjectString");
        nodeObjectString.Should().NotBeNull();
        nodeObjectString.Value.Should().BeEmpty();
        var nodeNodeObject = node.Element("NodeNodeObject");
        nodeNodeObject.Should().NotBeNull();
        nodeNodeObject.Value.Should().BeEmpty();
        var subObjects = node.Element("SubObjects");
        subObjects.Should().NotBeNull();
        subObjects.Elements().Should().BeEmpty();
    }
}
