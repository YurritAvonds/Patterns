namespace Patterns.InheritedBuilder.Base;

public abstract class BaseBuilder<TBaseObject, TBaseBuilder>
    where TBaseObject : new()
    where TBaseBuilder : BaseBuilder<TBaseObject, TBaseBuilder>
{
    protected TBaseObject builderObject = new();

    public TBaseObject Build() => builderObject;
}
