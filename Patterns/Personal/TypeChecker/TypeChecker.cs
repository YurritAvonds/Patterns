using System.Collections;
using System.ComponentModel;

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
        type = Nullable.GetUnderlyingType(type) ?? type;

        if (type.IsEnum)
            return true;

        if (type == typeof(string))
            return true;

        var converter = TypeDescriptor.GetConverter(type);
        return !type.IsClass
            && !type.IsCollectionType()
            && converter.CanConvertTo(typeof(string));
    }

    public static bool IsObjectType(this Type type)
    {
        return !type.IsCollectionType()
            && type.IsClass
            && type != typeof(string);
    }
}
