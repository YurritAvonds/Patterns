namespace Patterns.Standard.Facade;

public class Facade(string input)
{
    readonly SystemComponentOne componentOne = new("C1");
    readonly SystemComponentTwo componentTwo = new("C2");
    readonly SystemComponentThree componentThree = new("C3");

    public string Execute()
    {
        var result = componentOne.OperationOne(input);
        result = componentOne.OperationTwo(result);
        result = componentTwo.OperationOne(result);
        result = componentThree.OperationOne(result);
        result = componentThree.OperationTwo(result);

        return result;
    }
}
