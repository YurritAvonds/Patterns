namespace Patterns.Standard.Memento.Examples;

public interface IOriginator
{
    Originator.Memento CreateMemento();
    void RestoreMemento(Originator.Memento memento);
    void SetInteger(int newInteger);
    void SetString(string newString);
}