using Patterns.Standard.State.Concept;

namespace Patterns.Standard.State.Examples;

public class ConcreteContext(IConcreteState state) : Context<IConcreteState>(state)
{
    public ICollection<string> Results { get; set; } = [];

    public void Continue()
    {
        State.Handle(this);
    }
}
