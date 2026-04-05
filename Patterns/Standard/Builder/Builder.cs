namespace Patterns.Standard.Builder;

public class Builder
{
    protected BuildableObject buildableObject = new();

    /// <summary>
    /// Convenience method to build a new object, using an existing one as the starting point.
    /// </summary>
    /// <param name="existingObject">An existing object of the same type as the one that can be built by this builder.</param>
    /// <returns>The builder with the buildable object set to the existing object</returns>
    public Builder WithExisting(BuildableObject existingObject)
    {
        buildableObject = existingObject;
        return this;
    }

    /// <summary>
    /// Build methode returns the buildable object, usually after a series of calls to the
    /// With... methods.
    /// </summary>
    /// <returns>The built object</returns>
    public BuildableObject Build() => buildableObject;

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
