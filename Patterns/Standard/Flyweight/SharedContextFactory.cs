namespace Patterns.Standard.Flyweight;

public class SharedContextFactory
{
    public ICollection<SharedContext> Contexts { get; private set; } = [];

    public SharedContext GetSharedContext(string extrinsicValue)
    {
        if (Contexts.FirstOrDefault(c => c.ExtrinsicValue.Equals(extrinsicValue, StringComparison.Ordinal))
            is SharedContext existingContext)
        {
            return existingContext;
        }

        var newContext = new SharedContext(extrinsicValue);
        Contexts.Add(newContext);
        return newContext;
    }
}
