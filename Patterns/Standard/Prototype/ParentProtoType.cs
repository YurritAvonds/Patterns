namespace Patterns.Standard.Prototype;

public class ParentProtoType(string stringValue) : IPrototype
{
    public string StringProperty { get; set; } = stringValue;

    public virtual IPrototype Clone()
    {
        return new ParentProtoType(StringProperty);
    }
}
