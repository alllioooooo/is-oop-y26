namespace Itmo.ObjectOrientedProgramming.Lab4.Utilities.ResultTypes.ParserResultTypes;

public record FailureParserResult(string Message) : ParserResultType
{
    public override bool Success => false;
    public new string Message { get; } = Message;
}