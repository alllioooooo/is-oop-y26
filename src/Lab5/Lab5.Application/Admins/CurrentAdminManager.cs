using Lab5.Domain.Abstractions.Admins;
using Lab5.Domain.Contracts.Admins;

namespace Lab5.Application.Admins;

public class CurrentAdminManager : ICurrentAdminManager
{
    public IAdmin? Admin { get; set; }
}