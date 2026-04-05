namespace Patterns.Standard.Flyweight.Examples;

public class SharedContext(string extrinsicValue)
{
    public string ExtrinsicValue { get; } = extrinsicValue;

    public string Operate(string intrinsicValue)
        => $"SharedContext: {ExtrinsicValue} with intrinsic value: {intrinsicValue}";
}
