namespace Patterns.Standard.Observer.Examples;

public class ListenerOne : IListener
{
    public int Counter { get; private set; } = 0;

    public void Update(string input)
    {
        Counter += input.Length;
    }
}
