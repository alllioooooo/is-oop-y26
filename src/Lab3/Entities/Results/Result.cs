namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Results;

public abstract record Result
{
    public abstract bool Success { get; }
    public abstract string Message { get; }
}