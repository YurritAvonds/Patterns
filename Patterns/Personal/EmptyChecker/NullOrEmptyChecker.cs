using System.Collections;

namespace Patterns.Personal.EmptyChecker;

public class NullOrEmptyChecker : IEmptyChecker
{
    public bool IsEmpty<T>(object checkedObject)
    {
        if (checkedObject == null)
        {
            return true;
        }

        foreach (var property in typeof(T).GetProperties())
        {
            var propertyValue = property.GetValue(checkedObject);

            if (propertyValue is IEnumerable collection)
            {
                if (collection.Cast<object>().Any())
                {
                    return false;
                }
                else
                {
                    continue;
                }
            }

            if (propertyValue != null)
            {
                return false;
            }
        }
        return true;
    }
}
