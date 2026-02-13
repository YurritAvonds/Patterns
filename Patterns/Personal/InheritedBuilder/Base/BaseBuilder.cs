namespace Patterns.InheritedBuilder.Base;

public abstract class BaseBuilder<TBaseObject, TBaseBuilder>
    where TBaseObject : new()
    where TBaseBuilder : BaseBuilder<TBaseObject, TBaseBuilder>
{
    protected TBaseObject builderObject;

    public BaseBuilder()
    {
        builderObject = new TBaseObject();
    }

    public TBaseBuilder WithExisting(TBaseObject existingObject)
    {
        builderObject = existingObject;
        return (TBaseBuilder)this;
    }

    public TBaseObject Build() => builderObject;
}
