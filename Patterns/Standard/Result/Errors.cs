namespace Patterns.Standard.Result;

public static class Errors
{
    public static Error InputTooHigh { get; }
        = new(Id: ErrorType.InputTooHigh.ToString(), ErrorType.InputTooHigh, "Input too high.");
    public static Error InputTooLow { get; }
        = new(Id: ErrorType.InputTooLow.ToString(), ErrorType.InputTooLow, "Input too low.");
    public static Error InputNull { get; }
        = new(Id: ErrorType.InputNull.ToString(), ErrorType.InputNull, "Input null.");
}
