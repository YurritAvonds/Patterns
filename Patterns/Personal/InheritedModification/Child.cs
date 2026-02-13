namespace Patterns.Personal.InheritedModification;

public class Child : Parent
{
    public override Result Execute()
    {
        Result result = base.Execute();

        result.StringProperty = "Child";

        return result;
    }
}
