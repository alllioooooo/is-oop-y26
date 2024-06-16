using System.Diagnostics.CodeAnalysis;
using Lab5.Presentation.Console.Scenarios.Admins.Login;
using Lab5.Presentation.Console.Scenarios.Users.Login;

namespace Lab5.Presentation.Console.Scenarios.RoleChoice;

public class RoleChoiceScenarioProvider : IScenarioProvider
{
    private readonly UserLoginScenario _userLoginScenario;
    private readonly AdminLoginScenario _adminLoginScenario;

    public RoleChoiceScenarioProvider(UserLoginScenario userLoginScenario, AdminLoginScenario adminLoginScenario)
    {
        _userLoginScenario = userLoginScenario;
        _adminLoginScenario = adminLoginScenario;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new RoleChoiceScenario(_userLoginScenario, _adminLoginScenario);
        return true;
    }
}