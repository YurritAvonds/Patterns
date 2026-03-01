namespace Patterns.Standard.Command;

public class DecrementIntegerCommand(Receiver receiver) : ICommand
{
    private readonly Receiver receiver = receiver;

    public void Execute()
    {
        receiver.SetIntegerValue(receiver.GetIntegerValue() - 1);
    }
}
