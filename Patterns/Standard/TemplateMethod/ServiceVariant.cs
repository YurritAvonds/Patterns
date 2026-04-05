namespace Patterns.Standard.TemplateMethod;

public class ServiceVariant : Service
{
    /// <summary>
    /// Do not apply the ToUpper from the base implementation
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    protected override string StepOne(string input) => input;

    /// <summary>
    /// Append square brackets to the start and end of the input.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    protected override string StepThree(string input) => $"[{input}]";
}
