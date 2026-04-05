namespace Patterns.Standard.State.Concept;

public interface IState<TContext>
{
    void Handle(TContext context);
}
