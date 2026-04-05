namespace Patterns.Standard.TemplateMethod;

public class Service
{
    public string Process(string input)
    {
        var resultOne = StepOne(input);
        var resultTwo = StepTwo(resultOne);
        var resultThree = StepThree(resultTwo);

        return resultThree;
    }

    /// <summary>
    /// Convert to upper case.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    protected virtual string StepOne(string input) => input.ToUpper(CultureInfo.InvariantCulture);

    /// <summary>
    /// Revert the string
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    protected virtual string StepTwo(string input) => new([.. input.Reverse()]);

    /// <summary>
    /// Append asterisks to the start and end of the string.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    protected virtual string StepThree(string input) => $"*** {input} ***";
}
