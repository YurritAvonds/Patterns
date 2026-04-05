namespace Patterns.Standard.Bridge;

/// <summary>
/// A client will only interact with the abstraction, which will delegate to the implementation.
/// </summary>
/// <param name="implementation">Any concrete implementation of the implementation interface</param>
public class Abstraction(IImplementation implementation)
{
    public void IncrementValue()
        => implementation.SetCurrentValue(implementation.GetCurrentValue() + 1);

    public void DecrementValue()
        => implementation.SetCurrentValue(implementation.GetCurrentValue() - 1);

    public int ReadValue()
        => implementation.GetCurrentValue();

    public void ToggleEnabled()
        => implementation.SetEnabled(!implementation.GetEnabled());

    public bool IsEnabled()
        => implementation.GetEnabled();
}
