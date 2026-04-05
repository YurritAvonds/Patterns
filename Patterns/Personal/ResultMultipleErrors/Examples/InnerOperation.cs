using Patterns.Standard.Result.Concept;
using Result = Patterns.Personal.ResultMultipleErrors.Concept.Result<int?>;

namespace Patterns.Personal.ResultMultipleErrors.Examples;

internal class InnerOperation
{
    public static Result DoSomething(int? integerParameter)
    {
        if (integerParameter is null)
        {
            return Errors.InputNull;
        }

        if (integerParameter % 2 != 0)
        {
            return Errors.OddNumber;
        }

        return (Result)integerParameter.Value;
    }
}
