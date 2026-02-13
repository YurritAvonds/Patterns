using FluentAssertions;
using Patterns.Personal.InheritedModification;

namespace UnitTests.Personal.InheritedModification
{
    internal class ParentTests
    {
        protected IParent Creator;

        public ParentTests()
        {
            Creator = new Parent();
        }

        [Test]
        public virtual void Execute_ShouldReturnResultObjectWithParentString_WhenCalled()
        {
            // Arrange
            // Act
            Result result = Creator.Execute();
            // Assert
            result.StringProperty.Should().Be("Parent");
        }

        [Test]
        public void Execute_ShouldReturnResultObjectWithInt42_WhenCalled()
        {
            // Arrange
            // Act
            Result result = Creator.Execute();
            // Assert
            result.IntProperty.Should().Be(42);
        }

        [Test]
        public void Execute_ShouldReturnResultObjectWithBoolTrue_WhenCalled()
        {
            // Arrange
            // Act
            Result result = Creator.Execute();
            // Assert
            result.BoolProperty.Should().BeTrue();
        }

        [Test]
        public void Execute_ShouldReturnResultObjectWithDoublePi_WhenCalled()
        {
            // Arrange
            // Act
            Result result = Creator.Execute();
            // Assert
            result.DoubleProperty.Should().Be(3.14);
        }
    }
}
