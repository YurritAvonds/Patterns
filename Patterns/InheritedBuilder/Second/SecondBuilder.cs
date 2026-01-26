using Patterns.InheritedBuilder.First;

namespace Patterns.InheritedBuilder.Second;

public class SecondBuilder : SecondBuilder<SecondObject>
{
    public SecondBuilder() : base()
    { }
}

public class SecondBuilder<TSecondObject> : FirstBuilder<TSecondObject>
    where TSecondObject : SecondObject, new()
{
    public SecondBuilder<TSecondObject> WithName(string? name)
    {
        builderObject.Name = name;
        return this;
    }
}
