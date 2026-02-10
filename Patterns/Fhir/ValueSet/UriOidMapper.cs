using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Patterns.Fhir.ValueSet
{
    public static class UriOidMapper
    {
        public static string? FindCodeSystemUri(string oid)
        {
            foreach (var codeSystemProperty in typeof(CodeSystems).GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                if (codeSystemProperty.GetValue(null) is CodeSystem codeSystem
                    && codeSystem.Oid.Equals(oid, StringComparison.OrdinalIgnoreCase))
                {
                    return codeSystem.Uri;
                }
            }
            return null;
        }

        public static string? FindCodeSystemOid(string uri)
        {
            foreach (var codeSystemProperty in typeof(CodeSystems).GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                if (codeSystemProperty.GetValue(null) is CodeSystem codeSystem
                    && codeSystem.Uri.Equals(uri, StringComparison.OrdinalIgnoreCase))
                {
                    return codeSystem.Oid;
                }
            }
            return null;
        }

        public static string? FindValueSetUri(string oid)
        {
            foreach (var valueSetProperty in typeof(ValueSets).GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                if (valueSetProperty.GetValue(null) is ValueSet valueSet
                    && valueSet.Oid.Equals(oid, StringComparison.OrdinalIgnoreCase))
                {
                    return valueSet.Uri;
                }
            }
            return null;
        }

        public static string? FindValueSetOid(string uri)
        {
            foreach (var valueSetProperty in typeof(ValueSets).GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                if (valueSetProperty.GetValue(null) is ValueSet valueSet
                    && valueSet.Uri.Equals(uri, StringComparison.OrdinalIgnoreCase))
                {
                    return valueSet.Oid;
                }
            }
            return null;
        }
    }
}
