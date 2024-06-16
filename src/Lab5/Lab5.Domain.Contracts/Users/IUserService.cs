namespace Lab5.Domain.Contracts.Users;

public interface IUserService
{
    public Task<UserLoginResult> LoginAsync(string username);
    public void Logout();
}