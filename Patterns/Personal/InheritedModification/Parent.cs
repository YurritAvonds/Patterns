namespace Patterns.Personal.InheritedModification;

public class Parent : IParent
{
    public virtual Result Execute() => new()
    {
        StringProperty = "Parent",
        IntProperty = 42,
        BoolProperty = true,
        DoubleProperty = 3.14
    };
}
