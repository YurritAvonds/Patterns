using Patterns.Standard.Result.Concept;

namespace Patterns.Standard.Result.Examples;

internal class InnerOperation
{
    public static Result<int?> DoSomething(int? integerParameter)
    {
        if (integerParameter is null)
        {
            return Errors.InputNull;
        }

        if (integerParameter % 2 != 0)
        {
            return Errors.OddNumber;
        }

        return (Result<int?>)integerParameter.Value;
    }
}
