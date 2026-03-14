namespace Patterns.Standard.Flyweight;

public class SharedContext(string extrinsicValue)
{
    public string ExtrinsicValue { get; } = extrinsicValue;

    public string Operate(string intrinsicValue)
        => $"SharedContext: {ExtrinsicValue} with intrinsic value: {intrinsicValue}";
}
