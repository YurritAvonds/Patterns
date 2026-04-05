namespace Patterns.Standard.Memento.Examples;

public class Originator() : IMemento, IOriginator
{
    public string StateString { get; private set; } = string.Empty;
    public int StateInteger { get; private set; }

    public Memento CreateMemento() => new(StateString, StateInteger);

    public void RestoreMemento(Memento memento)
    {
        StateString = memento.StateString;
        StateInteger = memento.StateInteger;
    }

    public void SetString(string newString) => StateString = newString;

    public void SetInteger(int newInteger) => StateInteger = newInteger;

    public record Memento(string StateString, int StateInt) : IMemento
    {
        public string StateString { get; } = StateString;
        public int StateInteger { get; } = StateInt;
    }
}
