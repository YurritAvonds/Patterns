namespace Patterns.Standard.Result;

public record Error(string Id, ErrorType Type, string Description);
