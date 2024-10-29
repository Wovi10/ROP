namespace ROP;

public class NaNException : Exception
{
    public override string Message { get; } = "Input is not a number.";
}

public class NoZeroException : Exception
{
    public override string Message { get; } = "Roman numerals don't have a notion of zero.";
}