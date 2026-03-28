namespace Patterns.Standard.Observer;

public class Service
{
    private readonly List<IListener> listeners = [];

    public void Subscribe(IListener listener)
    {
        listeners.Add(listener);
    }

    public void Receive(string input)
    {
        UpdateListerns(input);
    }
    private void UpdateListerns(string input)
    {
        foreach (var listener in listeners)
        {
            listener.Update(input);
        }
    }
}
