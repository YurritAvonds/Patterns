using FluentAssertions;
using Patterns.Standard.Flyweight;

namespace UnitTests.Standard;

internal class FlyweightTests
{
    [Test]
    public void Flyweight_ShouldShareContexts()
    {
        // Arrange
        var factory = new SharedContextFactory();
        var results = new List<string>();

        // Act
        foreach (var extrinsicValue in new[] { "ContextA", "ContextB", "ContextA" })
        {
            foreach (var intrinsicValue in new[] { "ValueX", "ValueY", "ValueZ" })
            {
                var context = factory.GetSharedContext(extrinsicValue);
                var repeatedObject = new RepeatedObject(intrinsicValue, context);
                results.Add(repeatedObject.Operate());
            }
        }

        // Assert
        factory.Contexts.Should().SatisfyRespectively(
            context => context.ExtrinsicValue.Should().Be("ContextA"),
            context => context.ExtrinsicValue.Should().Be("ContextB")
        );
        results.Should().SatisfyRespectively(
            result => result.Should().Be("SharedContext: ContextA with intrinsic value: ValueX"),
            result => result.Should().Be("SharedContext: ContextA with intrinsic value: ValueY"),
            result => result.Should().Be("SharedContext: ContextA with intrinsic value: ValueZ"),
            result => result.Should().Be("SharedContext: ContextB with intrinsic value: ValueX"),
            result => result.Should().Be("SharedContext: ContextB with intrinsic value: ValueY"),
            result => result.Should().Be("SharedContext: ContextB with intrinsic value: ValueZ"),
            result => result.Should().Be("SharedContext: ContextA with intrinsic value: ValueX"),
            result => result.Should().Be("SharedContext: ContextA with intrinsic value: ValueY"),
            result => result.Should().Be("SharedContext: ContextA with intrinsic value: ValueZ")
        );
    }
}
