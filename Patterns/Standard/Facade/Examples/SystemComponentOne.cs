namespace Patterns.Standard.Facade.Examples;

internal class SystemComponentOne(string shared)
{
    public string OperationOne(string input) => $"<{shared}O1>{input}</{shared}O1>";

    public string OperationTwo(string input) => $"<{shared}O2>{input}</{shared}O2>";
}
