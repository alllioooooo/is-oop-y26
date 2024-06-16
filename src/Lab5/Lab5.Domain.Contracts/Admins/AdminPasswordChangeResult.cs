namespace Lab5.Domain.Contracts.Admins;

public abstract record AdminPasswordChangeResult
{
    public sealed record Success : AdminPasswordChangeResult;
    public sealed record AdminNotFound : AdminPasswordChangeResult;
}