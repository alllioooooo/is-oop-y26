namespace Itmo.ObjectOrientedProgramming.Lab4.Utilities.ResultTypes.CommandsResultTypes;

public record SuccessCommandsResult(string Message) : CommandsResultType
{
    public override bool Success => true;
    public override string Message { get; } = Message;
}