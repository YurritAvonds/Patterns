using FluentAssertions;
using Patterns.Fhir.ValueSet;

namespace UnitTests.Fhir;

internal class ValueSetTests
{
    [TestCase("http://hl7.org/fhir/task-intent", "unknown", true)]
    [TestCase("http://hl7.org/fhir/request-intent", "proposal", true)]
    [TestCase("http://hl7.org/fhir/request-intent", "plan", true)]
    [TestCase("http://hl7.org/fhir/request-intent", "order", true)]
    [TestCase("http://hl7.org/fhir/request-intent", "original-order", true)]
    [TestCase("http://hl7.org/fhir/request-intent", "reflex-order", true)]
    [TestCase("http://hl7.org/fhir/request-intent", "filler-oder", true)]
    [TestCase("http://hl7.org/fhir/request-intent", "instance-oder", true)]
    [TestCase("http://hl7.org/fhir/request-intent", "option", true)]
    [TestCase("http://in.correct.system", "option", false)]
    [TestCase("http://hl7.org/fhir/request-intent", "incorrect-value", false)]
    public void Contains_ShouldReturnTrue_WhenValueSetContainsCode(string system, string code, bool expectedResult)
    {
        // Arrange
        
        // Act
        var result = ValueSets.TaskIntent.ContainsCode(system, code);

        // Assert
        result.Should().Be(expectedResult);
    }
}
