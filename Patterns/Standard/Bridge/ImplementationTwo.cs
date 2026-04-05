namespace Patterns.Standard.Bridge;

/// <summary>
/// Example implementatioon
/// </summary>
public class ImplementationTwo : IImplementation
{
    private int value = 100;

    public int GetCurrentValue()
        => value;

    public void SetCurrentValue(int value)
        => this.value = value;

    public bool GetEnabled()
        => value >= 100;

    public void SetEnabled(bool enabled)
    {
        if (enabled && value < 100)
        {
            value = 100;
        }
        else if (!enabled && value >= 100)
        {
            value = 99;
        }
    }
}
