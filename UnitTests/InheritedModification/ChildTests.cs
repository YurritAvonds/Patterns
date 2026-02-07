using FluentAssertions;
using Patterns.InheritedModification;

namespace UnitTests.InheritedModification
{
    internal class ChildTests
    {
        [Test]
        public void Execute_ShouldReturnResultObjectWithParentString_WhenCalled()
        {
            // Arrange
            Child child = new();
            // Act
            Result result = child.Execute();
            // Assert
            result.StringProperty.Should().Be("Child");
        }

        [Test]
        public void Execute_ShouldReturnResultObjectWithInt42_WhenCalled()
        {
            // Arrange
            Child child = new();
            // Act
            Result result = child.Execute();
            // Assert
            result.IntProperty.Should().Be(42);
        }

        [Test]
        public void Execute_ShouldReturnResultObjectWithBoolTrue_WhenCalled()
        {
            // Arrange
            Child child = new();
            // Act
            Result result = child.Execute();
            // Assert
            result.BoolProperty.Should().BeTrue();
        }

        [Test]
        public void Execute_ShouldReturnResultObjectWithDoublePi_WhenCalled()
        {
            // Arrange
            Child child = new();
            // Act
            Result result = child.Execute();
            // Assert
            result.DoubleProperty.Should().Be(3.14);
        }
    }
}
