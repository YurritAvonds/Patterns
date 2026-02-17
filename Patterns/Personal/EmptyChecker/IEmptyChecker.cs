namespace Patterns.Personal.EmptyChecker;

public interface IEmptyChecker
{
    bool IsEmpty<T>(object checkedObject);
}
