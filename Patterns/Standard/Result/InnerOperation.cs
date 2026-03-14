namespace Patterns.Standard.Result;

internal class InnerOperation
{
    public Result<int?> DoSomething(int? integerParameter)
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
