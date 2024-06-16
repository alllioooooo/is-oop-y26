namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record NotCompatible : CompatibilityResult
{
    public NotCompatible(string? message)
    {
        Message = message;
    }

    public override string Status { get; } = "Not Compatible";
    public override string? Message { get; }
}