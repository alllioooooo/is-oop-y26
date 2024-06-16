namespace Itmo.ObjectOrientedProgramming.Lab4.Utilities.ResultTypes.CommandsResultTypes;

public record FailureCommandsResult(string Message) : CommandsResultType
{
    public override bool Success => false;
    public override string Message { get; } = Message;
}