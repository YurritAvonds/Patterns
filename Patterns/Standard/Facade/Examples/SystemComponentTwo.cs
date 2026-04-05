namespace Patterns.Standard.Facade.Examples;

internal class SystemComponentTwo(string shared)
{
    public string OperationOne(string input) => $"<{shared}O1>{input}</{shared}O1>";
}
