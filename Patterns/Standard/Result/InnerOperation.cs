namespace Patterns.Standard.Result;

internal class InnerOperation
{
    public Result<int?> DoSomething(int? integerParameter)
    {
        return integerParameter switch
        {
            null => (Result<int?>)Errors.InputNull,
            > 100 => (Result<int?>)Errors.InputTooHigh,
            < 0 => (Result<int?>)Errors.InputTooLow,
            _ => (Result<int?>)integerParameter.Value,
        };
    }
}
