using System.Globalization;

namespace Patterns.Personal.InheritedObjectTemplateMethod;

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
