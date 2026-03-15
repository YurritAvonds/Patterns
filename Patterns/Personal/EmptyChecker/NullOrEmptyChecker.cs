using System.Collections;

namespace Patterns.Personal.EmptyChecker;

/// <summary>
/// Checks whether an object is null or all of its properties are null or empty collections.
/// </summary>
public class NullOrEmptyChecker : IEmptyChecker
{
    /// <summary>
    /// Check whether an object is null or all of its properties are null or empty collections.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="checkedObject"></param>
    /// <returns></returns>
    public bool IsEmpty<T>(object checkedObject)
    {
        if (checkedObject == null)
        {
            return true;
        }

        foreach (var property in typeof(T).GetProperties())
        {
            if (!IsEmptyProperty(checkedObject, property))
            {
                return false;
            }
        }
        return true;
    }

    private static bool IsEmptyProperty(object checkedObject, System.Reflection.PropertyInfo property)
    {
        var propertyValue = property.GetValue(checkedObject);

        if (propertyValue is IEnumerable collection)
        {
            if (collection.Cast<object>().Any())
            {
                return false;
            }
        }
        else if (propertyValue != null)
        {
            return false;
        }

        return true;
    }
}
