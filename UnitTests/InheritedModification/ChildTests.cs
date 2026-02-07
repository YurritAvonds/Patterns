using FluentAssertions;
using Patterns.InheritedModification;

namespace UnitTests.InheritedModification
{
    internal class ChildTests : ParentTests
    {
        public ChildTests()
        {
            Creator = new Child();
        }

        [Test]
        public override void Execute_ShouldReturnResultObjectWithParentString_WhenCalled()
        {
            // Arrange
            Child child = new();
            // Act
            Result result = Creator.Execute();
            // Assert
            result.StringProperty.Should().Be("Child");
        }
    }
}
