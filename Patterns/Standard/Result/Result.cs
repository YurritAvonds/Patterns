namespace Patterns.Standard.Result;

public record Result<T>
{
    public bool IsSuccess { get; }
    public Error? Error { get; }
    public T? Value { get; }

    private Result(bool isSuccess, Error? error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    private Result(bool isSuccess, T value)
    {
        IsSuccess = isSuccess;
        Value = value;
    }

    public static Result<T> Success(T value)
        => new(true, value);

    public static Result<T> Failure(Error error)
        => new(false, error ?? throw new ArgumentNullException(nameof(error)));

    public static implicit operator Result<T>(T value)
        => Success(value);

    public static implicit operator Result<T>(Error error)
        => Failure(error);
}
