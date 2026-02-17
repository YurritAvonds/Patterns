namespace Patterns.Personal.EmptyChecker
{
    public class Parent(IEmptyChecker emptyChecker)
    {
        public string? ParentString { get; set; }
        public int? ParentInteger { get; set; }

        public virtual bool IsEmpty() => emptyChecker.IsEmpty<Parent>(this);
    }
}
