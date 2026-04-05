using Patterns.Personal.EmptyChecker.Concept;

namespace Patterns.Personal.EmptyChecker.Examples;

/// <summary>
/// Parent class that can check whether it and its parent are empty using the provided IEmptyChecker implementation.
/// </summary>
/// <param name="emptyChecker"></param>
public class Child(IEmptyChecker emptyChecker) : Parent(emptyChecker)
{
    private readonly IEmptyChecker emptyChecker = emptyChecker;
    public string? ChildString { get; set; }
    public int? ChildInteger { get; set; }
    public ICollection<string>? ChildCollection { get; set; }

    /// <summary>
    /// Checks whether the Child object and its Parent are empty based on the provided IEmptyChecker..
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty() => emptyChecker.IsEmpty<Child>(this)
        && base.IsEmpty();
}
