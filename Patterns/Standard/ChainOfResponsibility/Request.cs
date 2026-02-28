namespace Patterns.Standard.ChainOfResponsibility;

public record Request(string? StringValue, int? IntegerValue)
{
    public string? StringValue { get; set; } = StringValue;
    public int? IntegerValue { get; set; } = IntegerValue;
}
