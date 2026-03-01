namespace Patterns.Standard.Command;

public class ToggleBooleanCommand(Receiver receiver) : ICommand
{
    private readonly Receiver receiver = receiver;

    public void Execute()
    {
        receiver.SetBooleanValue(!receiver.GetBooleanValue());
    }
}
