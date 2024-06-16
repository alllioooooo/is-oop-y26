using Lab5.Domain.Abstractions.Users;

namespace Lab5.Domain.Models.Users;

public class User : IUser
{
    public User(long id, string username)
    {
        Id = id;
        Username = username;
    }

    public long Id { get; }

    public string Username { get; }
}