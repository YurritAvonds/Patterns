using FluentAssertions;

namespace UnitTests.Fhir;

internal class HumanNameTests
{
    [Test]
    [TestCase(new[] { "Dr.", "Mr." }, new[] { "John", "A." }, "Doe", new[] { "Jr." }, "Dr. Mr. John A. Doe Jr.")]
    [TestCase(null, new[] { "John" }, "Doe", null, "John Doe")]
    [TestCase(null, null, "Doe", null, "Doe")]
    [TestCase(null, new[] { "John" }, null, null, "John")]
    [TestCase(new[] { "Mr." }, null, null, null, "Mr.")]
    [TestCase(null, null, null, new[] { "Jr." }, "Jr.")]
    [TestCase(null, null, null, null, null)]
    public void FullName_ShouldReturnCorrectFullName(string[]? prefix, string[]? given, string? family,
        string[]? suffix, string? expectedFullName)
    {
        // Arrange
        var humanName = new Patterns.Fhir.HumanName.HumanName
        {
            Prefix = prefix,
            Given = given,
            Family = family,
            Suffix = suffix
        };

        // Act
        var fullName = humanName.FullName;

        // Assert
        fullName.Should().Be(expectedFullName);
    }
}
