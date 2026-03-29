namespace Patterns.Personal.InheritedObjectTemplateMethod;

public class ChildService<TSourceObject> : ParentService<TSourceObject>
    where TSourceObject : ChildObject
{
    protected override string CreateStringResult(TSourceObject sourceObject)
        => sourceObject.BooleanProperty
            ? $"[{sourceObject.StringProperty}]"
            : string.Empty;

    protected override double CreateDoubleResult(TSourceObject sourceObject)
        => sourceObject.IntegerProperty * sourceObject.DoubleProperty;
}
