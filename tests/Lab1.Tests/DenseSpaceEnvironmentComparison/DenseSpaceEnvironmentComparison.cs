using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.FuelExchange;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.DenseSpaceEnvironmentComparison;

public class DenseSpaceEnvironmentComparison
{
    private static readonly Route Route = new(new DenseSpaceEnvironment());

    private readonly List<IShip> _ships = new()
    {
        new PleasureShuttle(),
        new Augur(),
    };

    public DenseSpaceEnvironmentComparison()
    {
        ImpulseEngineFuelPricing.SetPricePerUnit(100);
        JumpEngineFuelPricing.SetPricePerUnit(200);
        Route.AddSegment(new RouteSegment(new List<IObstacle>(), 300));
    }

    [Fact]
    public void TestCase()
    {
        var routingService = new RoutingService(Route, _ships);
        string result = routingService.ExecuteRouting();

        Assert.Equal("Destroyed", result);
    }
}