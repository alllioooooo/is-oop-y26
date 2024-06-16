using Lab5.Domain.Abstractions.Admins;

namespace Lab5.Domain.Models.Admins;

public class Admin : IAdmin
{
    public Admin(long id, string username, string password)
    {
        Id = id;
        Username = username;
        Password = password;
    }

    public long Id { get; }

    public string Username { get; }

    public string Password { get; private set; }

    public void ChangePassword(string newPassword)
    {
        Password = newPassword;
    }
}