using Lab5.Domain.Abstractions.Users;

namespace Lab5.Domain.Contracts.Users;

public interface ICurrentUserManager
{
        public IUser? User { get; set; }
}