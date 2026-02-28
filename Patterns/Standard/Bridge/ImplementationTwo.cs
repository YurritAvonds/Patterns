namespace Patterns.Standard.Bridge;

public class ImplementationTwo : IImplementation
{
    private int value = 100;

    public int GetCurrentValue() => value;

    public bool GetEnabled() => value >= 100;

    public void SetCurrentValue(int value)
    {
        this.value = value;
    }

    public void SetEnabled(bool enabled)
    {
        if (enabled)
        {
            if (value < 100)
            {
                value = 100;
            }
        }
        else
        {
            if (value >= 100)
            {
                value = 99;
            }
        }
    }
}
