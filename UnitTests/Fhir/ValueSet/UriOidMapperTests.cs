using FluentAssertions;
using Patterns.Fhir.ValueSet;

namespace UnitTests.Fhir.ValueSet;

internal class UriOidMapperTests
{
    [TestCase("2.16.840.1.113883.4.642.4.1241", "http://hl7.org/fhir/task-intent")]
    [TestCase("2.16.840.1.113883.4.642.4.114", "http://hl7.org/fhir/request-intent")]
    public void FindCodeSystemUri_ShouldReturnUri_WhenCodeSystemExists(string oid, string expectedUri)
    {
        // Arrange

        // Act
        var actualUri = UriOidMapper.FindCodeSystemUri(oid);

        // Assert
        actualUri.Should().NotBeNull();
        actualUri.Should().Be(expectedUri);
    }

    [TestCase("http://some.incorrect.uri")]
    [TestCase("2.16.840.1.113883.4.642.4.555")]
    [TestCase("abc")]
    [TestCase(" ")]
    [TestCase("")]
    public void FindCodeSystemUri_ShouldReturnNull_WhenCodeSystemDoesNotExist(string oid)
    {
        // Arrange

        // Act
        var actualUri = UriOidMapper.FindCodeSystemUri(oid);

        // Assert
        actualUri.Should().BeNull();
    }

    [TestCase("2.16.840.1.113883.4.642.4.1241", "http://hl7.org/fhir/task-intent")]
    [TestCase("2.16.840.1.113883.4.642.4.114", "http://hl7.org/fhir/request-intent")]
    public void FindCodeSystemOid_ShouldReturnOid_WhenCodeSystemExists(string expectedOid, string uri)
    {
        // Arrange

        // Act
        var actualOid = UriOidMapper.FindCodeSystemOid(uri);

        // Assert
        actualOid.Should().NotBeNull();
        actualOid.Should().Be(expectedOid);
    }

    [TestCase("http://some.incorrect.uri")]
    [TestCase("2.16.840.1.113883.4.642.4.555")]
    [TestCase("abc")]
    [TestCase(" ")]
    [TestCase("")]
    public void FindCodeSystemOid_ShouldReturnNull_WhenCodeSystemDoesNotExist(string uri)
    {
        // Arrange

        // Act
        var actualOid = UriOidMapper.FindCodeSystemOid(uri);

        // Assert
        actualOid.Should().BeNull();
    }

    [TestCase("2.16.840.1.113883.4.642.3.1240", "http://hl7.org/fhir/ValueSet/task-intent")]
    public void FindValueSetUri_ShouldReturnUri_WhenValueSetExists(string oid, string expectedUri)
    {
        // Arrange

        // Act
        var actualUri = UriOidMapper.FindValueSetUri(oid);

        // Assert
        actualUri.Should().NotBeNull();
        actualUri.Should().Be(expectedUri);
    }

    [TestCase("http://some.incorrect.uri")]
    [TestCase("2.16.840.1.113883.4.642.4.555")]
    [TestCase("abc")]
    [TestCase(" ")]
    [TestCase("")]
    public void FindValueSetUri_ShouldReturnNull_WhenValueSetDoesNotExist(string oid)
    {
        // Arrange

        // Act
        var actualUri = UriOidMapper.FindValueSetUri(oid);

        // Assert
        actualUri.Should().BeNull();
    }

    [TestCase("2.16.840.1.113883.4.642.3.1240", "http://hl7.org/fhir/ValueSet/task-intent")]
    public void FindValueSetOid_ShouldReturnUri_WhenValueSetExists(string expectedOid, string uri)
    {
        // Arrange

        // Act
        var actualOid = UriOidMapper.FindValueSetOid(uri);

        // Assert
        actualOid.Should().NotBeNull();
        actualOid.Should().Be(expectedOid);
    }

    [TestCase("http://some.incorrect.uri")]
    [TestCase("2.16.840.1.113883.4.642.4.555")]
    [TestCase("abc")]
    [TestCase(" ")]
    [TestCase("")]
    public void FindValueSetOid_ShouldReturnNull_WhenValueSetDoesNotExist(string uri)
    {
        // Arrange

        // Act
        var actualOid = UriOidMapper.FindValueSetOid(uri);

        // Assert
        actualOid.Should().BeNull();
    }
}
