namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public abstract record CompatibilityResult
{
    public abstract string Status { get; }
    public abstract string? Message { get; }
}