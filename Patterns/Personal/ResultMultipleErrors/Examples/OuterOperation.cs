using Patterns.Standard.Result.Concept;
using Result = Patterns.Personal.ResultMultipleErrors.Concept.Result<int?>;

namespace Patterns.Personal.ResultMultipleErrors.Examples;

public class OuterOperation
{
    public static Result DoSomething(int? integerParameter)
    {
        var innerResult = InnerOperation.DoSomething(integerParameter);

        var outerResult = integerParameter switch
        {
            null => (Result)Errors.InputNull,
            > 100 => (Result)Errors.InputTooHigh,
            < 0 => (Result)Errors.InputTooLow,
            _ => (Result)integerParameter.Value,
        };

        outerResult.AddResult(innerResult);

        return outerResult;
    }
}
