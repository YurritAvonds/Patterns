namespace Patterns.InheritedBuilder.Base;

public abstract class BaseBuilder<TObject, TBuilder>
    where TObject : new()
    where TBuilder : BaseBuilder<TObject, TBuilder>
{
    protected TObject builderObject = new();

    public TObject Build() => builderObject;
}
