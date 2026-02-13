namespace Patterns.Factory;

public class FirstVariant(double commonParameter, int variantParameter) : IBaseType
{
    public double CommonProperty { get; set; } = commonParameter;
    public int VariantProperty { get; set; } = variantParameter;

    public bool SharedMethod()
        => CommonProperty > 10
            && VariantProperty > 12;
}
