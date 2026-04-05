using Patterns.Standard.State.Concept;

namespace Patterns.Standard.State.Examples;

/// <summary>
/// Non-generic interface for each of the concrete states.
/// Can optionally include some other required properties or methods.
/// </summary>
public interface IConcreteState : IState<ConcreteContext>
{
}
