using Patterns.Standard.Result.Concept;

namespace Patterns.Standard.Result.Examples;

public class OuterOperation
{
    public static Result<int?> DoSomething(int? integerParameter)
    {
        var innerResult = InnerOperation.DoSomething(integerParameter);

        if (!innerResult.IsSuccess)
        {
            return innerResult;
        }

        return integerParameter switch
        {
            null => (Result<int?>)Errors.InputNull,
            > 100 => (Result<int?>)Errors.InputTooHigh,
            < 0 => (Result<int?>)Errors.InputTooLow,
            _ => (Result<int?>)integerParameter.Value,
        };
    }
}
