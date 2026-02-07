using FluentAssertions;
using Patterns.InheritedModification;

namespace UnitTests.InheritedModification
{
    internal class ParentTests
    {
        [Test]
        public void Execute_ShouldReturnResultObjectWithParentString_WhenCalled()
        {
            // Arrange
            Parent parent = new();
            // Act
            Result result = parent.Execute();
            // Assert
            result.StringProperty.Should().Be("Parent");
        }

        [Test]
        public void Execute_ShouldReturnResultObjectWithInt42_WhenCalled()
        {
            // Arrange
            Parent parent = new();
            // Act
            Result result = parent.Execute();
            // Assert
            result.IntProperty.Should().Be(42);
        }

        [Test]
        public void Execute_ShouldReturnResultObjectWithBoolTrue_WhenCalled()
        {
            // Arrange
            Parent parent = new();
            // Act
            Result result = parent.Execute();
            // Assert
            result.BoolProperty.Should().BeTrue();
        }

        [Test]
        public void Execute_ShouldReturnResultObjectWithDoublePi_WhenCalled()
        {
            // Arrange
            Parent parent = new();
            // Act
            Result result = parent.Execute();
            // Assert
            result.DoubleProperty.Should().Be(3.14);
        }
    }
}
