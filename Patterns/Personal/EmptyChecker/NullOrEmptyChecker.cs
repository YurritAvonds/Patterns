using System.Collections;
using System.Reflection;

namespace Patterns.Personal.EmptyChecker
{
    public class NullOrEmptyChecker : IEmptyChecker
    {
        public bool IsEmpty<T>(object checkedObject)
        {
            foreach (var property in typeof(T).GetProperties())
            {
                if (
                    (property.GetValue(checkedObject) is object propertyValue
                     && propertyValue != null)
                    ||
                    (property.GetValue(checkedObject) is IEnumerable enumerable
                     && enumerable != null
                     && !enumerable.Cast<object>().Any())
                    )
                {
                    return false;
                }
            }
            return true;
        }
    }
}
