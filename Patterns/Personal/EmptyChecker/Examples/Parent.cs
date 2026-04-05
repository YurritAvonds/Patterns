using Patterns.Personal.EmptyChecker.Concept;

namespace Patterns.Personal.EmptyChecker.Examples;

/// <summary>
/// Parent class that can check whether it is empty using the provided IEmptyChecker implementation.
/// </summary>
/// <param name="emptyChecker"></param>
public class Parent(IEmptyChecker emptyChecker)
{
    private readonly IEmptyChecker emptyChecker = emptyChecker;
    public string? ParentString { get; set; }
    public int? ParentInteger { get; set; }
    public ICollection<string>? ParentCollection { get; set; }

    /// <summary>
    /// Checks whether the Parent object is empty by using the provided IEmptyChecker implementation.
    /// </summary>
    /// <returns></returns>
    public virtual bool IsEmpty() => emptyChecker.IsEmpty<Parent>(this);
}
