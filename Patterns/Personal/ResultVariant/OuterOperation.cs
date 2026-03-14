using Patterns.Standard.Result;

namespace Patterns.Personal.ResultVariant;

public class OuterOperation
{
    public static Result<int?> DoSomething(int? integerParameter)
    {
        var innerResult = InnerOperation.DoSomething(integerParameter);

        var outerResult = integerParameter switch
        {
            null => (Result<int?>)Errors.InputNull,
            > 100 => (Result<int?>)Errors.InputTooHigh,
            < 0 => (Result<int?>)Errors.InputTooLow,
            _ => (Result<int?>)integerParameter.Value,
        };

        outerResult.AddResult(innerResult);

        return outerResult;
    }
}
