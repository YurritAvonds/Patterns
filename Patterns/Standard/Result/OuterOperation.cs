namespace Patterns.Standard.Result;

public class OuterOperation
{
    public Result<int?> DoSomething(int? integerParameter)
    {
        var innerResult = new InnerOperation().DoSomething(integerParameter);

        if (!innerResult.IsSuccess)
        {
            return innerResult;
        }

        return integerParameter switch
        {
            null => (Result<int?>)Errors.InputNull,
            > 75 => (Result<int?>)Errors.InputTooHigh,
            < 25 => (Result<int?>)Errors.InputTooLow,
            _ => (Result<int?>)integerParameter.Value,
        };
    }
}
