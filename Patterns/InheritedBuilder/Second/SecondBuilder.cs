using Patterns.InheritedBuilder.First;

namespace Patterns.InheritedBuilder.Second;

public class SecondBuilder : SecondBuilder<SecondObject, SecondBuilder>
{
    public SecondBuilder() : base()
    { }
}

public class SecondBuilder<TSecondObject, TSecondBuilder> : FirstBuilder<TSecondObject, TSecondBuilder>
    where TSecondObject : SecondObject, new()
    where TSecondBuilder : SecondBuilder<TSecondObject, TSecondBuilder>
{
    public TSecondBuilder WithName(string? name)
    {
        builderObject.Name = name;
        return (TSecondBuilder)this;
    }
}
