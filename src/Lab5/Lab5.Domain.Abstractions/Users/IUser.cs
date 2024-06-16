namespace Lab5.Domain.Abstractions.Users;

public interface IUser
{
    public long Id { get; }

    public string Username { get; }
}