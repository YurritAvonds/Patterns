using Patterns.Standard.Result;

namespace Patterns.Personal.ResultVariant;

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
