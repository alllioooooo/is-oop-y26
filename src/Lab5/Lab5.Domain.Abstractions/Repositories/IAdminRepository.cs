using Lab5.Domain.Abstractions.Admins;

namespace Lab5.Domain.Abstractions.Repositories;

public interface IAdminRepository
{
    public Task<IAdmin?> FindAdminByUsernameAsync(string username);
    public Task AddAdminAsync(IAdmin admin);
    public Task<bool> UpdateAdminPasswordAsync(string username, string newPassword);
}