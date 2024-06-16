namespace Lab5.Domain.Contracts.Admins;

public interface IAdminService
{
    public ICurrentAdminManager CurrentAdminManager { get; }
    public Task<AdminLoginResult> LoginAsync(string username, string password);
    public Task<UserCreationResult> CreateUserAsync(string username);
    public Task<AdminPasswordChangeResult> ChangePasswordAsync(string username, string newPassword);
    public void Logout();
}