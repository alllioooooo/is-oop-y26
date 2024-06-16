namespace Itmo.ObjectOrientedProgramming.Lab4.Utilities.ResultTypes.CommandsResultTypes;

public abstract record CommandsResultType
{
    public abstract bool Success { get; }
    public abstract string Message { get; }
}