using FluentAssertions;
using Patterns.Personal.InheritedModification;

namespace UnitTests.Personal.InheritedModification
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
