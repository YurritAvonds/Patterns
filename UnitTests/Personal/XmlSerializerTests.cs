using FluentAssertions;
using Patterns.Personal.XmlSerializer;
using System.Xml;
using System.Xml.Linq;

namespace UnitTests.Personal;

internal class XmlSerializerTests
{
    private readonly XmlSerializer xmlSerializer;

    public XmlSerializerTests()
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
    [Category("Unit")]
    [TestCase("Test String")]
    [TestCase("")]
    public void Serialize_String(string input)
    {
        // Arrange
        var leaf = new Leaf
        {
            LeafString = input
        };

        // Act
        var result = xmlSerializer.Serialize(leaf);

        // Assert
        var doc = XElement.Parse(result);
        doc.Name.LocalName.Should().Be("Leaf");
        AssertLeaf(doc,
            leafString: input,
            leafInteger: string.Empty,
            leafBoolean: string.Empty);
    }

    [Test]
    [Category("Unit")]
    public void Serialize_String_Null()
    {
        // Arrange
        var leaf = new Leaf
        {
            LeafString = null
        };

        // Act
        var result = xmlSerializer.Serialize(leaf);

        // Assert
        var doc = XElement.Parse(result);
        doc.Name.LocalName.Should().Be("Leaf");
        AssertLeaf(doc,
            leafString: string.Empty,
            leafInteger: string.Empty,
            leafBoolean: string.Empty);
    }

    [Test]
    [Category("Unit")]
    [TestCase(-1, "-1")]
    [TestCase(0, "0")]
    [TestCase(1, "1")]
    public void Serialize_Integer(int input, string expected)
    {
        // Arrange
        var leaf = new Leaf
        {
            LeafInteger = input
        };

        // Act
        var result = xmlSerializer.Serialize(leaf);

        // Assert
        var doc = XElement.Parse(result);
        doc.Name.LocalName.Should().Be("Leaf");
        AssertLeaf(doc,
            leafString: string.Empty,
            leafInteger: expected,
            leafBoolean: string.Empty);
    }

    [Test]
    [Category("Unit")]
    public void Serialize_Integer_Null()
    {
        // Arrange
        var leaf = new Leaf
        {
            LeafInteger = null
        };

        // Act
        var result = xmlSerializer.Serialize(leaf);

        // Assert
        var doc = XElement.Parse(result);
        doc.Name.LocalName.Should().Be("Leaf");
        AssertLeaf(doc,
            leafString: string.Empty,
            leafInteger: string.Empty,
            leafBoolean: string.Empty);
    }

    [Test]
    [Category("Unit")]
    [TestCase(false, "False")]
    [TestCase(true, "True")]
    public void Serialize_Boolean(bool input, string expected)
    {
        // Arrange
        var leaf = new Leaf
        {
            LeafBoolean = input
        };

        // Act
        var result = xmlSerializer.Serialize(leaf);

        // Assert
        var doc = XElement.Parse(result);
        doc.Name.LocalName.Should().Be("Leaf");
        AssertLeaf(doc,
            leafString: string.Empty,
            leafInteger: string.Empty,
            leafBoolean: expected);
    }

    [Test]
    [Category("Unit")]
    public void Serialize_Boolean_Null()
    {
        // Arrange
        var leaf = new Leaf
        {
            LeafBoolean = null
        };

        // Act
        var result = xmlSerializer.Serialize(leaf);

        // Assert
        var doc = XElement.Parse(result);
        doc.Name.LocalName.Should().Be("Leaf");
        AssertLeaf(doc,
            leafString: string.Empty,
            leafInteger: string.Empty,
            leafBoolean: string.Empty);
    }

    [Test]
    [Category("Unit")]
    public void Serialize_Object_Unitialized()
    {
        // Arrange
        var root = new Root()
        {
            RootObject = null
        };

        // Act
        var result = xmlSerializer.Serialize(root);

        // Assert
        var doc = XElement.Parse(result);
        doc.Name.LocalName.Should().Be("Root");

        doc.Element("RootObject")?.Value.Should().BeEmpty();
        doc.Element("RootString")?.Value.Should().BeEmpty();
        doc.Element("RootInteger")?.Value.Should().BeEmpty();
        doc.Element("RootObjects")?.Value.Should().BeEmpty();
    }

    [Test]
    [Category("Unit")]
    public void Serialize_Object_Initialized()
    {
        // Arrange
        var root = new Root()
        {
            RootObject = new Leaf()
        };

        // Act
        var result = xmlSerializer.Serialize(root);

        // Assert
        var doc = XElement.Parse(result);
        doc.Name.LocalName.Should().Be("Root");

        AssertLeaf(doc,
            leafString: string.Empty,
            leafInteger: string.Empty,
            leafBoolean: string.Empty);
        doc.Element("RootString")?.Value.Should().BeEmpty();
        doc.Element("RootInteger")?.Value.Should().BeEmpty();
        doc.Element("RootObjects")?.Value.Should().BeEmpty();
    }

    [Test]
    [Category("Unit")]
    public void Serialize_Collection()
    {
        // Arrange
        var root = new Root();
        root.RootObjects?.Add(new Node()
        {
            NodeString = "Object1"
        });
        root.RootObjects?.Add(new Node()
        {
            NodeString = "Object2"
        });

        // Act
        var result = xmlSerializer.Serialize(root);

        // Assert
        var doc = XElement.Parse(result);
        doc.Name.LocalName.Should().Be("Root");

        doc.Element("RootObjects")?.Elements("Node")?.ToList()[0].Element("NodeString")?.Value.Should().Be("Object1");
        doc.Element("RootObjects")?.Elements("Node")?.ToList()[1].Element("NodeString")?.Value.Should().Be("Object2");
    }

    [Test]
    [Category("Unit")]
    public void Serialize_Collection_Empty()
    {
        // Arrange
        var root = new Root
        {
            RootObjects = []
        };

        // Act
        var result = xmlSerializer.Serialize(root);

        // Assert
        var doc = XElement.Parse(result);
        doc.Name.LocalName.Should().Be("Root");

        doc.Element("RootObjects")?.Elements("Node")?.Should().BeEmpty();
    }

    [Test]
    [Category("Unit")]
    public void Serialize_Collection_Null()
    {
        // Arrange
        var root = new Root
        {
            RootObjects = null
        };

        // Act
        var result = xmlSerializer.Serialize(root);

        // Assert
        var doc = XElement.Parse(result);
        doc.Name.LocalName.Should().Be("Root");

        doc.Element("RootObjects")?.Should().BeNull();
    }

    [Test]
    [Category("Integration")]
    public void Serialize_EmptyObject()
    {
        // Arrange
        var rootObject = new Root();
        rootObject.RootObjects?.Add(new Node());

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
        doc.Element("RootInteger")?.Value.Should().BeEmpty();

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
        rootObject.RootObjects?.Add(new Node()
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

        // Act
        var result = xmlSerializer.Serialize(rootObject);

        // Assert
        var doc = XElement.Parse(result);
        doc.Name.LocalName.Should().Be("Root");

        doc.Element("RootString")?.Value.Should().Be("L1_String");
        doc.Element("RootInteger")?.Value.Should().Be("1");

        AssertLeaf(
            doc.Element("RootObject"),
            "L2_String",
            "2",
            "True");

        doc.Element("RootObjects")?.Element("Node")?.Element("NodeString")?.Value.Should().Be("L1_String");
        doc.Element("RootObjects")?.Element("Node")?.Element("NodeObject")?.Element("NodeString")?.Value.Should().Be("L2_String");
        AssertLeaf(
            doc.Element("RootObjects")?.Element("Node")?.Element("NodeObject")?.Element("NodeObjects")?.Element("Leaf"),
            "L2_Coll_Obj",
            "2",
            "False");

        AssertLeaf(
            doc.Element("RootObjects")?.Element("Node")?.Element("NodeObjects")?.Element("Leaf"),
            "L1_Coll_Obj",
            "1",
            "False");
    }

    private static void AssertLeaf(XElement? leaf, string leafString, string leafInteger, string leafBoolean)
    {
        leaf.Should().NotBeNull();
        leaf.Element("LeafBoolean")?.Value.Should().NotBeNull();
        leaf.Element("LeafBoolean")?.Value.Should().Be(leafBoolean);
        leaf.Element("LeafString")?.Value.Should().NotBeNull();
        leaf.Element("LeafString")?.Value.Should().Be(leafString);
        leaf.Element("LeafInteger")?.Value.Should().NotBeNull();
        leaf.Element("LeafInteger")?.Value.Should().Be(leafInteger);
    }
}
