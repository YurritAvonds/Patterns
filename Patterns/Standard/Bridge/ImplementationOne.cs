namespace Patterns.Standard.Bridge;

public class ImplementationOne : IImplementation
{
    private int value = 1;
    private bool enabled = false;

    public int GetCurrentValue()
    {
        return value;
    }

    public bool GetEnabled()
    {
        return enabled;
    }

    public void SetCurrentValue(int value)
    {
        this.value = value;
    }

    public void SetEnabled(bool enabled)
    {
        this.enabled = enabled;
    }
}
