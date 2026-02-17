using System.Collections;
using System.Reflection;

namespace Patterns.Personal.EmptyChecker
{
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
                object? propertyValue = property.GetValue(checkedObject);

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
}
