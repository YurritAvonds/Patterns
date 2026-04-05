namespace Patterns.Standard.Observer.Examples;

public class ListenerTwo : IListener
{
    public List<string> MessageStore { get; private set; } = [];

    public void Update(string input)
    {
        MessageStore.Add(input);
    }
}
