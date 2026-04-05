namespace Patterns.Standard.Bridge.Examples;

/// <summary>
/// Example implementatioon
/// </summary>
public class ImplementationOne : IImplementation
{
    private int value = 1;
    private bool enabled = false;

    public int GetCurrentValue()
        => value;

    public void SetCurrentValue(int value)
        => this.value = value;

    public bool GetEnabled()
        => enabled;

    public void SetEnabled(bool enabled)
        => this.enabled = enabled;
}
