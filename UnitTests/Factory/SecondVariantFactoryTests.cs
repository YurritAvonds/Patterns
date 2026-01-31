using FluentAssertions;
using Patterns.Factory;

namespace UnitTests.Factory
{
    public class SecondVariantFactoryTests
    {
        [Test]
        public void SharedMethod_AllVariants_ReturnsExpectedResults()
        {
            // Arrange
            var factory = new SecondVariantFactory();

            // Act

            // Assert
            var expected = new[] { false, false, true };
            var i = 0;
            foreach (IBaseType variant in factory)
            {
                variant.SharedMethod().Should().Be(expected[i]);
                i++;
            }
        }
    }
}
