namespace Lab5.Domain.Contracts.Users;

public abstract record UserLoginResult
{
    private UserLoginResult() { }

    public sealed record Success : UserLoginResult;

    public sealed record NotFound : UserLoginResult;
}