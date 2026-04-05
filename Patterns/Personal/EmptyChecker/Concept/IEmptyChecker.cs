namespace Patterns.Personal.EmptyChecker.Concept;

public interface IEmptyChecker
{
    bool IsEmpty<T>(object checkedObject);
}
