namespace Patterns.Standard.Command;

public class Receiver
{
    private bool booleanValue = true;
    private int integerValue = 100;

    public void SetBooleanValue(bool value) => booleanValue = value;

    public bool GetBooleanValue() => booleanValue;

    public void SetIntegerValue(int value) => integerValue = value;

    public int GetIntegerValue() => integerValue;
}