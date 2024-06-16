using Lab5.Domain.Abstractions.Users;
using Lab5.Domain.Contracts.Users;

namespace Lab5.Application.Users;

public class CurrentUserManager : ICurrentUserManager
{
    public IUser? User { get; set; }
}