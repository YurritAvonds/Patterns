namespace Patterns.Factory;

public class SecondVariant(double commonParameter, string variantParameter) : IBaseType
{
    public double CommonProperty { get; set; } = commonParameter;
    public string variantProperty { get; set; } = variantParameter;

    public bool SharedMethod()
        => CommonProperty > 5
            && !string.IsNullOrWhiteSpace(variantProperty);
}
