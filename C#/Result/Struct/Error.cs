namespace Result.Struct;

/// <summary>
/// Wraps an error value to make the failure case explicitly visible in the type system
/// when used as the error type of a <see cref="Result{TValue,TError}"/>.
/// </summary>
/// <typeparam name="T">The type of the contained error value.</typeparam>
public readonly struct Error<T>(T value)
{
    /// <summary>
    /// Gets the contained error value.
    /// </summary>
    public T Value => value;

    /// <summary>
    /// Implicitly converts a value of type <typeparamref name="T"/> to an <see cref="Error{T}"/>.
    /// </summary>
    /// <param name="value">The error value to wrap.</param>
    public static implicit operator Error<T>(T value) => new(value);
}
