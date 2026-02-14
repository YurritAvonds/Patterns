namespace Patterns.Standard.Builder;

public class Builder
{
    protected BuildableObject buildableObject;

    public Builder()
    {
        buildableObject = new BuildableObject();
    }

    public Builder WithExisting(BuildableObject existingObject)
    {
        buildableObject = existingObject;
        return this;
    }

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

    public BuildableObject Build() => buildableObject;
}
