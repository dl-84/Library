using System;
using Result.Types;

namespace Result;

/// <summary>
/// Represents the outcome of an operation that can either succeed or fail.
/// Forces explicit handling of both cases — errors cannot be silently ignored.
/// </summary>
/// <typeparam name="TValue">The type of the success value.</typeparam>
/// <typeparam name="TError">The type of the error content inside <see cref="Error{TError}"/>.</typeparam>
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

    /// <summary>
    /// Gets a value indicating whether the operation failed.
    /// </summary>
    public bool IsError { get; }

    /// <summary>
    /// Gets a value indicating whether the operation succeeded.
    /// </summary>
    public bool IsSuccess => !IsError;

    /// <summary>
    /// Implicitly converts a success value to a <see cref="Result{TValue,TError}"/>.
    /// </summary>
    /// <param name="value">The success value to wrap.</param>
    public static implicit operator Result<TValue, TError>(TValue value) => new(value);

    /// <summary>
    /// Implicitly converts an <see cref="Error{TError}"/> to a <see cref="Result{TValue,TError}"/>.
    /// </summary>
    /// <param name="error">The error to wrap.</param>
    public static implicit operator Result<TValue, TError>(Error<TError> error) => new(error);

    /// <summary>
    /// Evaluates the result by invoking one of two functions depending on the current state.
    /// Both functions must return the same type.
    /// </summary>
    /// <typeparam name="TResult">The return type of both functions.</typeparam>
    /// <param name="success">Invoked with the success value when no error is present.</param>
    /// <param name="failure">Invoked with the <see cref="Error{TError}"/> when an error is present.</param>
    /// <returns>The value returned by whichever function was invoked.</returns>
    public TResult Match<TResult>(Func<TValue, TResult> success, Func<Error<TError>, TResult> failure) =>
        !IsError ? success(_value!) : failure(_error!.Value);

    /// <summary>
    /// Evaluates the result by invoking one of two actions depending on the current state.
    /// </summary>
    /// <param name="success">Invoked with the success value when no error is present.</param>
    /// <param name="failure">Invoked with the <see cref="Error{TError}"/> when an error is present.</param>
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

    /// <summary>
    /// Chains a subsequent operation that itself returns a <see cref="Result{TNewValue,TError}"/>.
    /// If either this result or the subsequent operation is an error, the error is propagated immediately.
    /// Enables composing multiple failable steps without nested conditionals.
    /// </summary>
    /// <typeparam name="TNewValue">The success value type of the subsequent operation.</typeparam>
    /// <param name="mapper">A function that receives the success value and returns a new result.</param>
    /// <returns>The result of the subsequent operation, or the original error.</returns>
    public Result<TNewValue, TError> AndThen<TNewValue>(Func<TValue, Result<TNewValue, TError>> mapper) =>
        Match<Result<TNewValue, TError>>(mapper, error => error);

    /// <summary>
    /// Transforms the success value using the provided function.
    /// If the result is an error, the error is passed through unchanged without invoking the function.
    /// </summary>
    /// <typeparam name="TNewValue">The type of the transformed success value.</typeparam>
    /// <param name="mapper">A function that transforms the success value into a new type.</param>
    /// <returns>A new result containing the transformed value, or the original error.</returns>
    public Result<TNewValue, TError> Map<TNewValue>(Func<TValue, TNewValue> mapper) =>
        Match<Result<TNewValue, TError>>(value => mapper(value), error => error);
}
