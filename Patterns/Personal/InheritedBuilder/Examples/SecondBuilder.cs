namespace Patterns.Personal.InheritedBuilder.Examples;

/// <summary>
/// Convenience wrapper class that inherits from the generic base builder class with the type parameters set
/// so that you can initialize a builder without having to specify the type parameters.
/// </summary>
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
