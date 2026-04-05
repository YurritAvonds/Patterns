namespace Patterns.Standard.Flyweight.Examples;

public class RepeatedObject(string intrinsicValue, SharedContext extrinsicContext)
{
    public string Operate()
        => extrinsicContext.Operate(intrinsicValue);
}
