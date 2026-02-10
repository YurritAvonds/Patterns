using System.Reflection;

namespace Patterns.Fhir.ValueSet;

public static class UriOidMapper
{
    public static string? FindCodeSystemUri(string oid) => FindUri(oid, typeof(CodeSystems));
    public static string? FindValueSetUri(string oid) => FindUri(oid, typeof(ValueSets));
    public static string? FindCodeSystemOid(string uri) => FindOid(uri, typeof(CodeSystems));
    public static string? FindValueSetOid(string uri) => FindOid(uri, typeof(ValueSets));

    private static string? FindUri(string oid, Type systemType)
    {
        foreach (var systemProperty in systemType.GetFields(BindingFlags.Static | BindingFlags.Public))
        {
            if (systemProperty.GetValue(null) is ISystem system
                && system.Oid.Equals(oid, StringComparison.OrdinalIgnoreCase))
            {
                return system.Uri;
            }
        }
        return null;
    }

    private static string? FindOid(string uri, Type systemType)
    {
        foreach (var systemProperty in systemType.GetFields(BindingFlags.Static | BindingFlags.Public))
        {
            if (systemProperty.GetValue(null) is ISystem system
                && system.Uri.Equals(uri, StringComparison.OrdinalIgnoreCase))
            {
                return system.Oid;
            }
        }
        return null;
    }
}
