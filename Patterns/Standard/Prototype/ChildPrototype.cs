namespace Patterns.Standard.Prototype;

public class ChildPrototype(string stringValue, int integerValue) : ParentProtoType(stringValue)
{
    public int IntegerProperty { get; private set; } = integerValue;

    public override IPrototype Clone()
    {
        return new ChildPrototype(StringProperty, IntegerProperty);
    }
}
