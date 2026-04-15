using System.Xml.Linq;

namespace UnitTests.Asserters;

internal static class XmlAsserter
{
    public static void HasValue(this XElement? element, string expectedValue)
    {
        element?.Value.Should().Be(expectedValue);
    }
}
