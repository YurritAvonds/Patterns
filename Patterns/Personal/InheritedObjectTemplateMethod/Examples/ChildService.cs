namespace Patterns.Personal.InheritedObjectTemplateMethod.Examples;

/// <summary>
/// Child Service only needs to define overrides for the steps that it wants to handle differently from
/// the Parent Service.
/// </summary>
/// <typeparam name="TSourceObject">The type of object that will be handled by the service.</typeparam>
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
