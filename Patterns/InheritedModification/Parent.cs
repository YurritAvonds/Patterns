namespace Patterns.InheritedModification;

public class Parent
{
    public virtual Result Execute() => new()
    {
        StringProperty = "Parent",
        IntProperty = 42,
        BoolProperty = true,
        DoubleProperty = 3.14
    };
}
