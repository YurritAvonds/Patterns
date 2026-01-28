using Patterns.InheritedBuilder.Base;

namespace Patterns.InheritedBuilder.First;

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
