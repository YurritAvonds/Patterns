using Patterns.InheritedBuilder.Base;

namespace Patterns.InheritedBuilder.First;

public class FirstBuilder<TFirstObject> : BaseBuilder<TFirstObject, FirstBuilder<TFirstObject>>
    where TFirstObject : FirstObject, new()
{
    public FirstBuilder<TFirstObject> WithId(int id)
    {
        builderObject.Id = id;
        return this;
    }
}
