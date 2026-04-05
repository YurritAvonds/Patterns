namespace Patterns.Standard.Bridge.Examples;

/// <summary>
/// Interface for implementations that the abstraction is compatible with.
/// </summary>
public interface IImplementation
{
    public int GetCurrentValue();
    public void SetCurrentValue(int value);
    public bool GetEnabled();
    public void SetEnabled(bool enabled);
}
