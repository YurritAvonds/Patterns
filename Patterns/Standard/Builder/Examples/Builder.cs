namespace Patterns.Standard.Builder;

public partial class Builder
{
    public Builder WithIntegerValue(int value)
    {
        buildableObject.IntegerValue = value;
        return this;
    }

    public Builder WithStringValue(string value)
    {
        buildableObject.StringValue = value;
        return this;
    }

    public Builder WithBooleanValue(bool booleanValue)
    {
        buildableObject.BooleanValue = booleanValue;
        return this;
    }
}
