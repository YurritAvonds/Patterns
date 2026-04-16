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

    public static void HasEmptyValue(this XElement? element)
        => element?.Value.Should().BeEmpty();

    public static void HasValue(this XElement? element, string expectedValue)
        => element?.Value.Should().Be(expectedValue);

    public static void HasSingleEmptyElement(this XElement? element, string elementName)
        => element?.HasSingle(elementName)?.HasEmptyValue();

    public static void HasSingleElementWithValue(this XElement? element, string elementName, string expectedValue)
        => element?.HasSingle(elementName)?.HasValue(expectedValue);

    public static XElement? HasSingle(this XElement? element, string childElementName)
        => element?.Elements(childElementName).Single();

    public static void HasNoElement(this XElement? element, string childElementName)
        => element?.Elements(childElementName).Should().BeEmpty();

    public static IList<XElement> HasMultiple(this XElement? element, string childElementName, int amount)
    {
        var relevantElements = element?.Elements(childElementName);
        relevantElements?.Count().Should().Be(amount);
        return relevantElements?.ToList() ?? [];
    }

    public static void HasElementsWithValues(this XElement? element, string elementName,
        string[] expectedValues)
    {
        if (element?.Elements(elementName)?.ToList() is not List<XElement> elements)
        {
            return;
        }

        for (var i = 0; i < elements.Count; i++)
        {
            elements[i].HasValue(expectedValues[i]);
        }
    }
}
