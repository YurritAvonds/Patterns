using System.Collections;

namespace Patterns.Personal.TypeChecker;

public static class TypeChecker
{
    public static bool IsCollectionType(this Type type)
    {
        return type != typeof(string)
            && typeof(IEnumerable).IsAssignableFrom(type);
    }

    public static bool IsSimpleType(this Type type)
    {
        return type.IsPrimitive
            || type.IsEnum
            || type == typeof(string)
            || type == typeof(int?)
            || type == typeof(double)
            || type == typeof(double?)
            || type == typeof(decimal)
            || type == typeof(decimal?)
            || type == typeof(bool)
            || type == typeof(bool?)
            || type == typeof(DateTime)
            || type == typeof(DateTime?)
            || type == typeof(DateOnly)
            || type == typeof(DateOnly?)
            || type == typeof(TimeOnly)
            || type == typeof(TimeOnly?)
            || type == typeof(DateTimeOffset)
            || type == typeof(DateTimeOffset?)
            || type == typeof(TimeSpan)
            || type == typeof(TimeSpan?)
            || type == typeof(Guid);
    }

    public static bool IsObjectType(this Type type)
    {
        return !type.IsCollectionType()
            && type.IsClass
            && type != typeof(string);
    }
}
