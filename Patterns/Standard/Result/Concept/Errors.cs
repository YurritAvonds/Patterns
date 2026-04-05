namespace Patterns.Standard.Result.Concept;

public static class Errors
{
    public static Error InputTooHigh { get; }
        = new(ErrorType.InputTooHigh, "Input too high.");
    public static Error InputTooLow { get; }
        = new(ErrorType.InputTooLow, "Input too low.");
    public static Error InputNull { get; }
        = new(ErrorType.InputNull, "Input null.");
    public static Error OddNumber { get; }
        = new(ErrorType.InputOddNumber, "Input is odd number.");
    public static Error EvenNumber { get; }
        = new(ErrorType.InputEvenNumber, "Input is even number.");
}
