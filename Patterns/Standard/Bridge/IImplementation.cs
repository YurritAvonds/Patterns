namespace Patterns.Standard.Bridge;

public interface IImplementation
{
    public int GetCurrentValue();
    public void SetCurrentValue(int value);

    public bool GetEnabled();
    public void SetEnabled(bool enabled);
}
