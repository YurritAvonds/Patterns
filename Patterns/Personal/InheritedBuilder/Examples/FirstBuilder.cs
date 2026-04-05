using Patterns.Personal.InheritedBuilder.Concept;

namespace Patterns.Personal.InheritedBuilder.Examples;

/// <summary>
/// Convenience wrapper class that inherits from the generic base builder class with the type parameters set
/// so that you can initialize a builder without having to specify the type parameters.
/// </summary>
public class FirstBuilder : FirstBuilder<FirstObject, FirstBuilder>
{
    public FirstBuilder() : base()
    { }
}

public class FirstBuilder<TFirstObject, TFirstBuilder> : BaseBuilder<TFirstObject, TFirstBuilder>
    where TFirstObject : FirstObject, new()
    where TFirstBuilder : FirstBuilder<TFirstObject, TFirstBuilder>
{
    public TFirstBuilder WithId(int id)
    {
        builderObject.Id = id;
        return (TFirstBuilder)this;
    }
}
