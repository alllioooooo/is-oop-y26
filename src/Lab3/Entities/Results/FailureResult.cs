namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Results;

public record FailureResult(string Message) : Result
{
    public override bool Success => false;
    public override string Message { get; } = Message;
}