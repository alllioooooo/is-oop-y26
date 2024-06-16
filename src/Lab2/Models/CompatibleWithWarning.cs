namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record CompatibleWithWarning : CompatibilityResult
{
    public CompatibleWithWarning(string? message)
    {
        Message = message;
    }

    public override string Status { get; } = "Warning";
    public override string? Message { get; }
}