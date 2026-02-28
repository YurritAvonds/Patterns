namespace Patterns.Personal.EmptyChecker;

public class Parent(IEmptyChecker emptyChecker)
{
    private readonly IEmptyChecker emptyChecker = emptyChecker;
    public string? ParentString { get; set; }
    public int? ParentInteger { get; set; }
    public ICollection<string>? ParentCollection { get; set; }

    public virtual bool IsEmpty() => emptyChecker.IsEmpty<Parent>(this);
}
