using Patterns.InheritedBuilder.Second;

namespace Patterns.InheritedBuilder.Third;

public class ThirdBuilder : ThirdBuilder<ThirdObject>
{
    public ThirdBuilder() : base()
    { }
}

public class ThirdBuilder<TThirdObject> : SecondBuilder<TThirdObject>
    where TThirdObject : ThirdObject, new()
{
    public ThirdBuilder<TThirdObject> WithIsEmployed(bool isEmployed)
    {
        builderObject.IsEmployed = isEmployed;
        return this;
    }
}
