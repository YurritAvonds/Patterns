namespace Patterns.InheritedBuilder.Base;

public abstract class BaseBuilder<TObject>
    where TObject : new()
{
    protected TObject builderObject = new();

    public TObject Build() => builderObject;
}
