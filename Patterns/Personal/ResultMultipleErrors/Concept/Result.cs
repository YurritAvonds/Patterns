using Patterns.Standard.Result.Concept;

namespace Patterns.Personal.ResultMultipleErrors.Concept;

public record Result<T>
{
    public bool IsSuccess { get; private set; }
    public ICollection<Error> Errors { get; } = [];
    public T? Value { get; private set; }

    private Result(bool isSuccess, Error? error)
    {
        IsSuccess = isSuccess;
        if (error is not null)
        {
            Errors.Add(error);
        }
    }

    private Result(bool isSuccess, T value)
    {
        IsSuccess = isSuccess;
        Value = value;
    }

    public void AddResult(Result<T> result)
    {
        IsSuccess &= result.IsSuccess;
        Value = IsSuccess ? result.Value : default;

        foreach (var error in result.Errors)
        {
            if (!Errors.Contains(error))
            {
                Errors.Add(error);
            }
        }
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
