using FluentAssertions;
using Patterns.Standard.Factory;

namespace UnitTests.Standard
{
    public class FactoryTests
    {
        [Test]
        public void FirstVariantFactory()
        {
            // Arrange

            // Act
            var factory = new FirstVariantFactory();

            // Assert
            var expected = new[] { false, false, true };
            var i = 0;
            foreach (IBaseType variant in factory)
            {
                variant.SharedMethod().Should().Be(expected[i]);
                i++;
            }
        }

        [Test]
        public void SecondVariantFactory()
        {
            // Arrange
            var factory = new SecondVariantFactory();

            // Act

            // Assert
            var expected = new[] { true, true, false };
            var i = 0;
            foreach (IBaseType variant in factory)
            {
                variant.SharedMethod().Should().Be(expected[i]);
                i++;
            }
        }
    }
}
