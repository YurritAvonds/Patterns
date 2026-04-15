using System.Xml.Linq;

namespace UnitTests.Asserters;

internal static class XmlAsserter
{
    public static XElement IsValidXmlNamed(this string xmlString, string expectedName)
    {
        var doc = XElement.Parse(xmlString);
        doc.Name.LocalName.Should().Be(expectedName);

        return doc;
    }

    public static void HasElementValue(this XElement? element, string elementName, string expectedValue)
        => element?.Element(elementName)?.Value.Should().Be(expectedValue);

    public static void HasEmptyElement(this XElement? element, string elementName)
        => element?.Element(elementName)?.Value.Should().BeEmpty();

    public static void HasSingleEmptyElement(this XElement? element, string elementName)
        => element?.Elements(elementName)?.Single()?.Value.Should().BeEmpty();

    public static void HasSingleElementWithValue(this XElement? element, string elementName, string expectedValue)
        => element?.Elements(elementName)?.Single()?.Value.Should().Be(expectedValue);

    public static void HasElementsWithValues(this XElement? element, string elementName, string[] expectedValues)
    {
        var elements = element?.Elements(elementName).ToList();
        if (elements != null)
        {
            for (var i = 0; i < elements.Count; i++)
            {
                elements[i].Value.Should().Be(expectedValues[i]);
            }
        }
    }

    public static XElement HasSingle(this XElement? element, string childElementName)
        => element?.Elements(childElementName).Single();
}
