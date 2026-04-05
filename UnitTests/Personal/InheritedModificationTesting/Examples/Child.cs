namespace UnitTests.Personal.InheritedModificationTesting.Examples;

public class Child : Parent
{
    public override Result Execute()
    {
        var result = base.Execute();

        result.StringProperty = "Child";

        return result;
    }
}
