using System;
using Result.Types;

namespace Result;

public readonly struct Result<TValue, TError>
{
    private readonly Error<TError>? _error;

    private readonly TValue? _value;

    private Result(TValue value)
    {
        IsError = false;
        _value = value;
        _error = null;
    }

    private Result(Error<TError> error)
    {
        IsError = true;
        _error = error;
        _value = default;
    }

    public bool IsError { get; }

    public bool IsSuccess => !IsError;

    public static implicit operator Result<TValue, TError>(TValue value) => new(value);

    public static implicit operator Result<TValue, TError>(Error<TError> error) => new(error);

    public TResult Match<TResult>(Func<TValue, TResult> success, Func<Error<TError>, TResult> failure) =>
        !IsError ? success(_value!) : failure(_error!.Value);

    public void Match(Action<TValue> success, Action<Error<TError>> failure)
    {
        if (!IsError)
        {
            success(_value!);
        }
        else
        {
            failure(_error!.Value);
        }
    }

    public Result<TNewValue, TError> AndThen<TNewValue>(Func<TValue, Result<TNewValue, TError>> mapper) =>
        Match<Result<TNewValue, TError>>(mapper, error => error);

    public Result<TNewValue, TError> Map<TNewValue>(Func<TValue, TNewValue> mapper) =>
        Match<Result<TNewValue, TError>>(value => mapper(value), error => error);
}
