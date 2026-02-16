namespace Patterns.Standard.Memento;

public class Client(IOriginator originator)
{
    private readonly IOriginator originator = originator;
    private readonly ICollection<Originator.Memento> history = [];

    public void SetString(string newString)
    {
        // Save current state before changing it
        history.Add(originator.CreateMemento());

        // Change state
        originator.SetString(newString);
    }

    public void SetInteger(int newInteger)
    {
        // Save current state before changing it
        history.Add(originator.CreateMemento());

        // Change state
        originator.SetInteger(newInteger);
    }

    public void Undo()
    {
        if (history.Count <= 0)
        {
            return;
        }

        // Get the last saved state and remove it from history
        Originator.Memento lastMemento = Pop();

        // Restore the originator's state
        originator.RestoreMemento(lastMemento);
    }

    private Originator.Memento Pop()
    {
        var lastMemento = history.Last();
        history.Remove(lastMemento);

        return lastMemento;
    }
}
