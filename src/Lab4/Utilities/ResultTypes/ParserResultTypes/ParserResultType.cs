using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Utilities.ResultTypes.ParserResultTypes;

public abstract record ParserResultType
{
    public abstract bool Success { get; }
    public ICommand? Result { get; }
    public string? Message { get; }
}