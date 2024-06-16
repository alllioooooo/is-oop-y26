using Lab5.Domain.Abstractions.Repositories;
using Lab5.Domain.Abstractions.Users;
using Lab5.Domain.Contracts.Users;

namespace Lab5.Application.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository, CurrentUserManager currentUserManager)
    {
        _repository = repository;
        CurrentUserManager = currentUserManager;
    }

    public CurrentUserManager CurrentUserManager { get; set; }

    public async Task<UserLoginResult> LoginAsync(string username)
    {
        IUser? user = await _repository.FindUserByUsernameAsync(username);

        if (user == null)
        {
            return new UserLoginResult.NotFound();
        }

        CurrentUserManager.User = user;
        return new UserLoginResult.Success();
    }

    public void Logout()
    {
        CurrentUserManager.User = null;
    }
}