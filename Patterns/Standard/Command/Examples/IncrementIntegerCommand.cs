using Patterns.Standard.Command.Concept;

namespace Patterns.Standard.Command.Examples;

public class IncrementIntegerCommand(Receiver receiver) : ICommand
{
    private readonly Receiver receiver = receiver;

    public void Execute()
    {
        receiver.SetIntegerValue(receiver.GetIntegerValue() + 1);
    }
}
