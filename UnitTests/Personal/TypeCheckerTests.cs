using FluentAssertions;
using Patterns.Personal.TypeChecker;

namespace UnitTests.Personal;

internal class TypeCheckerTests
{
    private enum SampleEnum { A, B }

    private class SampleClass { }

    [Test]
    [TestCase(typeof(SampleClass), false)]
    [TestCase(typeof(object), false)]

    [TestCase(typeof(List<int>), false)]
    [TestCase(typeof(int[]), false)]
    [TestCase(typeof(IEnumerable<int>), false)]

    [TestCase(typeof(int), true)]
    [TestCase(typeof(SampleEnum), true)]
    [TestCase(typeof(string), true)]
    [TestCase(typeof(int?), true)]
    [TestCase(typeof(double), true)]
    [TestCase(typeof(double?), true)]
    [TestCase(typeof(decimal), true)]
    [TestCase(typeof(decimal?), true)]
    [TestCase(typeof(bool), true)]
    [TestCase(typeof(bool?), true)]
    [TestCase(typeof(DateTime), true)]
    [TestCase(typeof(DateTime?), true)]
    [TestCase(typeof(DateOnly), true)]
    [TestCase(typeof(DateOnly?), true)]
    [TestCase(typeof(TimeOnly), true)]
    [TestCase(typeof(TimeOnly?), true)]
    [TestCase(typeof(DateTimeOffset), true)]
    [TestCase(typeof(DateTimeOffset?), true)]
    [TestCase(typeof(TimeSpan), true)]
    [TestCase(typeof(TimeSpan?), true)]
    [TestCase(typeof(Guid), true)]
    public void IsSimpleType(Type type, bool expected)
    {
        // Act
        var result = type.IsSimpleType();

        // Assert
        result.Should().Be(expected);
    }

    [Test]
    [TestCase(typeof(SampleClass), false)]
    [TestCase(typeof(object), false)]

    [TestCase(typeof(List<int>), true)]
    [TestCase(typeof(int[]), true)]
    [TestCase(typeof(IEnumerable<int>), true)]

    [TestCase(typeof(int), false)]
    [TestCase(typeof(SampleEnum), false)]
    [TestCase(typeof(string), false)]
    [TestCase(typeof(int?), false)]
    [TestCase(typeof(double), false)]
    [TestCase(typeof(double?), false)]
    [TestCase(typeof(decimal), false)]
    [TestCase(typeof(decimal?), false)]
    [TestCase(typeof(bool), false)]
    [TestCase(typeof(bool?), false)]
    [TestCase(typeof(DateTime), false)]
    [TestCase(typeof(DateTime?), false)]
    [TestCase(typeof(DateOnly), false)]
    [TestCase(typeof(DateOnly?), false)]
    [TestCase(typeof(TimeOnly), false)]
    [TestCase(typeof(TimeOnly?), false)]
    [TestCase(typeof(DateTimeOffset), false)]
    [TestCase(typeof(DateTimeOffset?), false)]
    [TestCase(typeof(TimeSpan), false)]
    [TestCase(typeof(TimeSpan?), false)]
    [TestCase(typeof(Guid), false)]
    public void IsCollectionType(Type type, bool expected)
    {
        // Act
        var result = type.IsCollectionType();

        // Assert
        result.Should().Be(expected);
    }

    [Test]
    [TestCase(typeof(SampleClass), true)]
    [TestCase(typeof(object), true)]

    [TestCase(typeof(List<int>), false)]
    [TestCase(typeof(int[]), false)]
    [TestCase(typeof(IEnumerable<int>), false)]

    [TestCase(typeof(int), false)]
    [TestCase(typeof(SampleEnum), false)]
    [TestCase(typeof(string), false)]
    [TestCase(typeof(int?), false)]
    [TestCase(typeof(double), false)]
    [TestCase(typeof(double?), false)]
    [TestCase(typeof(decimal), false)]
    [TestCase(typeof(decimal?), false)]
    [TestCase(typeof(bool), false)]
    [TestCase(typeof(bool?), false)]
    [TestCase(typeof(DateTime), false)]
    [TestCase(typeof(DateTime?), false)]
    [TestCase(typeof(DateOnly), false)]
    [TestCase(typeof(DateOnly?), false)]
    [TestCase(typeof(TimeOnly), false)]
    [TestCase(typeof(TimeOnly?), false)]
    [TestCase(typeof(DateTimeOffset), false)]
    [TestCase(typeof(DateTimeOffset?), false)]
    [TestCase(typeof(TimeSpan), false)]
    [TestCase(typeof(TimeSpan?), false)]
    [TestCase(typeof(Guid), false)]
    public void IsObjectType(Type type, bool expected)
    {
        // Act
        var result = type.IsObjectType();

        // Assert
        result.Should().Be(expected);
    }
}
