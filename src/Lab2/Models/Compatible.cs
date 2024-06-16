namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record Compatible : CompatibilityResult
{
    public Compatible(string? message)
    {
        Message = message;
    }

    public override string Status { get; } = "Compatible";
    public override string? Message { get; }
}