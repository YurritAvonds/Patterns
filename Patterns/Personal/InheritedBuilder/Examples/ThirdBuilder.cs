namespace Patterns.Personal.InheritedBuilder.Examples;

/// <summary>
/// Convenience wrapper class that inherits from the generic base builder class with the type parameters set
/// so that you can initialize a builder without having to specify the type parameters.
/// </summary>
public class ThirdBuilder : ThirdBuilder<ThirdObject, ThirdBuilder>
{
    public ThirdBuilder() : base()
    { }
}

public class ThirdBuilder<TThirdObject, TThirdBuilder> : SecondBuilder<TThirdObject, TThirdBuilder>
    where TThirdObject : ThirdObject, new()
    where TThirdBuilder : ThirdBuilder<TThirdObject, TThirdBuilder>
{
    public TThirdBuilder WithIsEmployed(bool isEmployed)
    {
        builderObject.IsEmployed = isEmployed;
        return (TThirdBuilder)this;
    }
}
