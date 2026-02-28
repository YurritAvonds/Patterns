namespace Patterns.Standard.Bridge;

public class Abstraction(IImplementation implementation)
{
    public void IncrementValue()
    {
        implementation.SetCurrentValue(implementation.GetCurrentValue() + 1);
    }

    public void DecrementValue()
    {
        implementation.SetCurrentValue(implementation.GetCurrentValue() - 1);
    }

    public int ReadValue() => implementation.GetCurrentValue();

    public void ToggleEnabled()
    {
        implementation.SetEnabled(!implementation.GetEnabled());
    }

    public bool IsEnabled() => implementation.GetEnabled();
}
