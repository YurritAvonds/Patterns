namespace Patterns.Standard.Command;

public class Invoker
{
    private ICommand? command;

    public void SetCommand(ICommand command) => this.command = command;

    public void ExecuteCommand() => command?.Execute();
}
