using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.FuelExchange;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.OptimalRouteSpaceEnvironmentTest;

public class OptimalRouteSpaceEnvironmentTest
{
    private static readonly Route ShortSpaceRoute = new(new SpaceEnvironment());

    private readonly IShip _pleasureShuttle = new PleasureShuttle();
    private readonly IShip _vaclas = new Vaclas();
    private readonly RoutingService _routingService;

    public OptimalRouteSpaceEnvironmentTest()
    {
        ImpulseEngineFuelPricing.SetPricePerUnit(100);
        JumpEngineFuelPricing.SetPricePerUnit(200);
        ShortSpaceRoute.AddSegment(new RouteSegment(new List<IObstacle>(), 100));
        _routingService = new RoutingService(ShortSpaceRoute, new List<IShip> { _pleasureShuttle, _vaclas });
    }

    [Fact]
    public void TestOptimalShipInSpaceEnvironment()
    {
        IShip optimalShip = DetermineCheapestShip() ?? throw new InvalidOperationException();
        string result = _routingService.ExecuteRouting();

        Assert.Equal(_pleasureShuttle, optimalShip);
        Assert.Equal("Succeed", result);
    }

    private IShip? DetermineCheapestShip()
    {
        return new List<IShip> { _pleasureShuttle, _vaclas }.MinBy(ship => RoutingService.FlightCost(ship, ShortSpaceRoute));
    }
}