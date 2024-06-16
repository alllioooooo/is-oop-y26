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

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.OptimalRouteDenseSpaceEnvironmentTest;

public class OptimalRouteDenseSpaceEnvironmentTest
{
    private static readonly Route MediumDenseSpaceRoute = new(new DenseSpaceEnvironment());

    private readonly IShip _augur = new Augur();
    private readonly IShip _stella = new Stella();
    private readonly RoutingService _routingService;

    public OptimalRouteDenseSpaceEnvironmentTest()
    {
        ImpulseEngineFuelPricing.SetPricePerUnit(100);
        JumpEngineFuelPricing.SetPricePerUnit(200);
        MediumDenseSpaceRoute.AddSegment(new RouteSegment(new List<IObstacle>(), 400));
        _routingService = new RoutingService(MediumDenseSpaceRoute, new List<IShip> { _augur, _stella });
    }

    [Fact]
    public void TestOptimalShipInDenseSpaceEnvironment()
    {
        IShip optimalShip = DetermineOptimalShip() ?? throw new InvalidOperationException();
        string result = _routingService.ExecuteRouting();

        Assert.Equal(_stella, optimalShip);
        Assert.Equal("Succeed", result);
    }

    private IShip? DetermineOptimalShip()
    {
        return new List<IShip> { _augur, _stella }.MinBy(ship => RoutingService.FlightCost(ship, MediumDenseSpaceRoute));
    }
}