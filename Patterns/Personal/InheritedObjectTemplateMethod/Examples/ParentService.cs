namespace Patterns.Personal.InheritedObjectTemplateMethod.Examples;

/// <summary>
/// Parent Service defines all steps that go into creating the result and virtual basic methods for
/// each of the steps.
/// </summary>
/// <typeparam name="TSourceObject">The type of object that will be handled by the service.</typeparam>
public class ParentService<TSourceObject>
    where TSourceObject : ParentObject
{
    public ResultObject CreateResult(TSourceObject sourceObject)
    {
        var result = new ResultObject
        {
            StringResult = CreateStringResult(sourceObject),
            DoubleResult = CreateDoubleResult(sourceObject)
        };
        return result;
    }

    protected virtual double CreateDoubleResult(TSourceObject sourceObject)
        => (double)sourceObject.IntegerProperty / 2;

    protected virtual string CreateStringResult(TSourceObject sourceObject)
        => sourceObject.StringProperty.ToUpper(CultureInfo.InvariantCulture);
}
