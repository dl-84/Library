namespace Result.Types;

/// <summary>
/// Represents the absence of a meaningful return value in a <see cref="Result.Result{TValue,TError}"/>.
/// Use instead of <c>bool</c> when an operation either succeeds with no value or fails with an error.
/// </summary>
public readonly struct Unit
{
    /// <summary>
    /// Gets the singleton instance of <see cref="Unit"/>.
    /// </summary>
    public static readonly Unit Value = new();
}
