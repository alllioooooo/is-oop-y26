using Lab5.Domain.Abstractions.Admins;
using Lab5.Domain.Abstractions.Repositories;
using Lab5.Domain.Abstractions.Users;
using Lab5.Domain.Contracts.Admins;
using Lab5.Domain.Models.Users;

namespace Lab5.Application.Admins;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _repository;
    private readonly IUserRepository _userRepository;

    public AdminService(IAdminRepository repository, IUserRepository userRepository, CurrentAdminManager currentAdminManager)
    {
        _repository = repository;
        _userRepository = userRepository;
        CurrentAdminManager = currentAdminManager;
    }

    public ICurrentAdminManager CurrentAdminManager { get; }

    public async Task<AdminLoginResult> LoginAsync(string username, string password)
    {
        IAdmin? admin = await _repository.FindAdminByUsernameAsync(username);

        if (admin == null)
        {
            return new AdminLoginResult.NotFound();
        }

        if (admin.Password != password)
        {
            return new AdminLoginResult.WrongPassword();
        }

        CurrentAdminManager.Admin = admin;
        return new AdminLoginResult.Success();
    }

    public async Task<UserCreationResult> CreateUserAsync(string username)
    {
        IUser? existingUser = await _userRepository.FindUserByUsernameAsync(username);
        if (existingUser != null)
        {
            return new UserCreationResult.UsernameAlreadyExists();
        }

        var newUser = new User(0, username);
        await _userRepository.AddUserAsync(newUser);

        return new UserCreationResult.Success();
    }

    public async Task<AdminPasswordChangeResult> ChangePasswordAsync(string username, string newPassword)
    {
        IAdmin? admin = await _repository.FindAdminByUsernameAsync(username);

        if (admin == null)
        {
            return new AdminPasswordChangeResult.AdminNotFound();
        }

        admin.ChangePassword(newPassword);
        await _repository.UpdateAdminPasswordAsync(username, newPassword);

        return new AdminPasswordChangeResult.Success();
    }

    public void Logout()
    {
        CurrentAdminManager.Admin = null;
    }
}