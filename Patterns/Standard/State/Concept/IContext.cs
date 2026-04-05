namespace Patterns.Standard.State.Concept;

public interface IContext<TState>
{
    TState State { get; }

    void SetState(TState state);
}