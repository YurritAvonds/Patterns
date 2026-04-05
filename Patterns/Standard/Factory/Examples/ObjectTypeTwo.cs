namespace Patterns.Standard.Factory.Examples;

/// <summary>
/// Object type one, containing a common property and a property specific to this type.
/// Also contains some method that does something with the properties.
/// </summary>
/// <param name="commonParameter">iInput parameter for the property defined in the base type</param>
/// <param name="variantParameter">Input parameter for the property unique to object type two</param>
public class ObjectTypeTwo(double commonParameter, string variantParameter) : IBaseType
{
    public double CommonProperty { get; set; } = commonParameter;
    public string TypeTwoProperty { get; set; } = variantParameter;

    public bool Method()
        => CommonProperty > 5
            && !string.IsNullOrWhiteSpace(TypeTwoProperty);
}
