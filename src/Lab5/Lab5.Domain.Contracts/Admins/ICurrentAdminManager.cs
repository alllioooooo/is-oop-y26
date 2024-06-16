using Lab5.Domain.Abstractions.Admins;

namespace Lab5.Domain.Contracts.Admins;

public interface ICurrentAdminManager
{
    public IAdmin? Admin { get; set; }
}