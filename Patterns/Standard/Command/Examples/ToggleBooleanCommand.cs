using Patterns.Standard.Command.Concept;

namespace Patterns.Standard.Command.Examples;

public class ToggleBooleanCommand(Receiver receiver) : ICommand
{
    private readonly Receiver receiver = receiver;

    public void Execute()
    {
        receiver.SetBooleanValue(!receiver.GetBooleanValue());
    }
}
