namespace Lab5.Domain.Contracts.Admins;

public abstract record UserCreationResult
{
    public sealed record Success : UserCreationResult;

    public sealed record UsernameAlreadyExists : UserCreationResult;
}