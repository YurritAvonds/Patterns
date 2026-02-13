using FluentAssertions;
using Patterns.Standard.Factory;

namespace UnitTests.Standard.Factory
{
    public class FirstVariantFactoryTests
    {
        [Test]
        public void SharedMethod_AllVariants_ReturnsExpectedResults()
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
    }
}
