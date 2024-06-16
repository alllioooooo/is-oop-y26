namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Results;

public record SuccessResult(string Message) : Result
{
    public override bool Success => true;
    public override string Message { get; } = Message;
}