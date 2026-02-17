namespace Patterns.Personal.EmptyChecker;

public class Child(IEmptyChecker emptyChecker) : Parent(emptyChecker)
{
    public string? ChildString { get; set; }
    public int? ChildInteger { get; set; }
    public ICollection<string>? ChildCollection { get; set; }

    public override bool IsEmpty() => emptyChecker.IsEmpty<Child>(this)
        && base.IsEmpty();
}
