namespace Lab5.Domain.Abstractions.Admins;

public interface IAdmin
{
    public long Id { get; }

    public string Username { get; }

    public string Password { get; }

    public void ChangePassword(string newPassword);
}