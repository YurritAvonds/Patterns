namespace Patterns.Standard.Flyweight;

public class RepeatedObject(string intrinsicValue, SharedContext extrinsicContext)
{
    public string Operate()
        => extrinsicContext.Operate(intrinsicValue);
}
