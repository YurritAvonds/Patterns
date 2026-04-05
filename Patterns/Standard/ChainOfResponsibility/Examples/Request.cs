namespace Patterns.Standard.ChainOfResponsibility.Examples;

public record Request(string? StringValue, int? IntegerValue)
{
    public string? StringValue { get; set; } = StringValue;
    public int? IntegerValue { get; set; } = IntegerValue;
}
