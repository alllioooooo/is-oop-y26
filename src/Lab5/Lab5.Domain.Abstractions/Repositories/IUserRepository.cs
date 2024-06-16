using Lab5.Domain.Abstractions.Users;

namespace Lab5.Domain.Abstractions.Repositories;

public interface IUserRepository
{
    public Task<IUser?> FindUserByUsernameAsync(string username);
    public Task AddUserAsync(IUser user);
}