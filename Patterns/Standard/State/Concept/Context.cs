namespace Patterns.Standard.State.Concept;

public class Context<TState>(TState initialState) : IContext<TState>
{
    public TState State { get; private set; } = initialState;

    public void SetState(TState state)
    {
        State = state;
    }
}
