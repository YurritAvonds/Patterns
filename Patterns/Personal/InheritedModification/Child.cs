namespace Patterns.Personal.InheritedModification;

public class Child : Parent
{
    public override Result Execute()
    {
        var result = base.Execute();

        result.StringProperty = "Child";

        return result;
    }
}
