using Patterns.InheritedBuilder.Second;

namespace Patterns.InheritedBuilder.Third;

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
