using FluentAssertions;
using Newtonsoft.Json.Linq;
using Patterns.Personal.Serializers.Examples;
using UnitTests.Personal.Serializers.Examples;

namespace UnitTests.Personal.Serializers;

internal class JsonSerializerTests
{
    private readonly JsonSerializer jsonSerializer;

    public JsonSerializerTests()
    {
        jsonSerializer = new JsonSerializer();
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
        var result = jsonSerializer.Serialize(leaf);

        // Assert
        var doc = JObject.Parse(result);
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
        var result = jsonSerializer.Serialize(leaf);

        // Assert
        var doc = JObject.Parse(result);
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
        var result = jsonSerializer.Serialize(leaf);

        // Assert
        var doc = JObject.Parse(result);
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
        var result = jsonSerializer.Serialize(leaf);

        // Assert
        var doc = JObject.Parse(result);
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
        var result = jsonSerializer.Serialize(leaf);

        // Assert
        var doc = JObject.Parse(result);
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
        var result = jsonSerializer.Serialize(leaf);

        // Assert
        var doc = JObject.Parse(result);
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
        var result = jsonSerializer.Serialize(root);

        // Assert
        var doc = JObject.Parse(result);
        doc["RootString"]?.Value<string>().Should().BeEmpty();
        doc["RootObject"]?.Should().BeEmpty();
        doc["RootInteger"]?.Value<string>().Should().BeEmpty();
        doc["RootObjects"]?.ToList().Should().BeEmpty();
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
        var result = jsonSerializer.Serialize(root);

        // Assert
        var doc = JObject.Parse(result);
        AssertLeaf(doc,
            leafString: string.Empty,
            leafInteger: string.Empty,
            leafBoolean: string.Empty);
        doc["RootString"]?.Value<string>().Should().BeEmpty();
        doc["RootInteger"]?.Value<string>().Should().BeEmpty();
        doc["RootObjects"]?.ToList().Should().BeEmpty();
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
        var result = jsonSerializer.Serialize(root);

        // Assert
        var doc = JObject.Parse(result);
        doc["RootObjects"]?.ToList()[0]["NodeString"]?.Value<string>().Should().Be("Object1");
        doc["RootObjects"]?.ToList()[1]["NodeString"]?.Value<string>().Should().Be("Object2");
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
        var result = jsonSerializer.Serialize(root);

        // Assert
        var doc = JObject.Parse(result);
        doc["RootObjects"]?.ToList().Should().BeEmpty();
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
        var result = jsonSerializer.Serialize(root);

        // Assert
        var doc = JObject.Parse(result);
        doc["RootObjects"]?.Should().BeEmpty();
    }

    [Test]
    [Category("Integration")]
    public void Serialize_EmptyObject()
    {
        // Arrange
        var rootObject = new Root();
        rootObject.RootObjects?.Add(new Node());

        // Act
        var result = jsonSerializer.Serialize(rootObject);

        // Assert
        var doc = JObject.Parse(result);

        doc["RootObject"].Should().NotBeNull();
        doc["RootObject"]?.Should().BeEmpty();

        doc["RootString"].Should().NotBeNull();
        doc["RootString"]?.Should().BeEmpty();

        doc["RootInteger"].Should().NotBeNull();
        doc["RootInteger"]?.Should().BeEmpty();

        doc["RootObjects"].Should().NotBeNull();
        doc["RootObjects"]?.ToList().Should().HaveCount(1);
        doc["RootObjects"]?.ToList()[0]["NodeString"]?.Should().NotBeNull();
        doc["RootObjects"]?.ToList()[0]["NodeString"]?.Should().BeEmpty();
        doc["RootObjects"]?.ToList()[0]["NodeObject"]?.Should().NotBeNull();
        doc["RootObjects"]?.ToList()[0]["NodeObject"]?.Should().BeEmpty();
        doc["RootObjects"]?.ToList()[0]["NodeObjects"]?.Should().NotBeNull();
        doc["RootObjects"]?.ToList()[0]["NodeObjects"]?.Should().BeEmpty();
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
        var result = jsonSerializer.Serialize(rootObject);

        // Assert
        var doc = JObject.Parse(result);

        doc["RootString"]?.Value<string>().Should().Be("L1_String");
        doc["RootInteger"]?.Value<string>().Should().Be("1");

        AssertLeaf(
            doc["RootObject"],
            "L2_String",
            "2",
            "True");

        doc["RootObjects"]?.First()["NodeString"]?.Value<string>().Should().Be("L1_String");
        doc["RootObjects"]?.First()["NodeObject"]?["NodeString"]?.Value<string>().Should().Be("L2_String");
        AssertLeaf(
            doc["RootObjects"]?.First()["NodeObject"]?["NodeObjects"]?.First(),
            "L2_Coll_Obj",
            "2",
            "False");

        AssertLeaf(
            doc["RootObjects"]?.First()["NodeObjects"]?.First(),
            "L1_Coll_Obj",
            "1",
            "False");
    }

    private static void AssertLeaf(JToken? leaf, string leafString, string leafInteger, string leafBoolean)
    {
        leaf.Should().NotBeNull();
        leaf["LeafBoolean"]?.Value<string>().Should().NotBeNull();
        leaf["LeafBoolean"]?.Value<string>().Should().Be(leafBoolean);
        leaf["LeafString"]?.Value<string>().Should().NotBeNull();
        leaf["LeafString"]?.Value<string>().Should().Be(leafString);
        leaf["LeafInteger"]?.Value<string>().Should().NotBeNull();
        leaf["LeafInteger"]?.Value<string>().Should().Be(leafInteger);
    }

    private static void AssertLeaf(JObject? leaf, string leafString, string leafInteger, string leafBoolean)
    {
        leaf.Should().NotBeNull();
        leaf["LeafBoolean"]?.Value<string>().Should().NotBeNull();
        leaf["LeafBoolean"]?.Value<string>().Should().Be(leafBoolean);
        leaf["LeafString"]?.Value<string>().Should().NotBeNull();
        leaf["LeafString"]?.Value<string>().Should().Be(leafString);
        leaf["LeafInteger"]?.Value<string>().Should().NotBeNull();
        leaf["LeafInteger"]?.Value<string>().Should().Be(leafInteger);
    }
}
