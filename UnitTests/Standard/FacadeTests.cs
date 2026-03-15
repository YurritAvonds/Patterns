using FluentAssertions;
using Patterns.Standard.Facade;

namespace UnitTests.Standard;

internal class FacadeTests
{
    [Test]
    public void FacadeExecutesSystemComponents_WithoutClientCallingThem()
    {
        // Arrange
        var facade = new Facade("testinput");

        // Act
        var result = facade.Execute();

        // Assert
        result.Should().Be("<C3O2><C3O1><C2O1><C1O2><C1O1>testinput</C1O1></C1O2></C2O1></C3O1></C3O2>");
    }
}
