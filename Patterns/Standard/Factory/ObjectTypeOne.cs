namespace Patterns.Standard.Factory;

/// <summary>
/// Object type one, containing a common property and a property specific to this type.
/// Also contains some method that does something with the properties.
/// </summary>
/// <param name="commonValue">iInput parameter for the property defined in the base type</param>
/// <param name="typeOneValue">Input parameter for the property unique to object type one</param>
public class ObjectTypeOne(double commonValue, int typeOneValue) : IBaseType
{
    public double CommonProperty { get; set; } = commonValue;
    public int TypeOneProperty { get; set; } = typeOneValue;

    public bool Method()
        => CommonProperty > 10
            && TypeOneProperty > 12;
}
