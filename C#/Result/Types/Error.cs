namespace Result.Types;

public readonly struct Error<T>(T value)
{
    public T Value => value;

    public static implicit operator Error<T>(T value) => new(value);
}
