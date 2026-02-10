using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.Fhir.ValueSet;

public static class ValueSets
{
    public static readonly ValueSet TaskIntent = new(
        "http://hl7.org/fhir/ValueSet/task-intent",
        "2.16.840.1.113883.4.642.3.1240")
    {
        Codes = [
            CodeSystems.TaskIntent,
            CodeSystems.RequestIntent
        ]
    };
}
