using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.NitrogenParticleEnvironmentTest;

public class NitrogenParticleEnvironmentTest
{
    private static readonly Route
        NitrogenParticleRoute =
            new(new NitrogenParticleEnvironment());

    private readonly IShip _pleasureShuttle = new PleasureShuttle();
    private readonly IShip _vaclas = new Vaclas();
    private readonly RoutingService _routingService;

    public NitrogenParticleEnvironmentTest()
    {
        NitrogenParticleRoute.AddSegment(new RouteSegment(
            new List<IObstacle>(),
            100));
        _routingService = new RoutingService(NitrogenParticleRoute, new List<IShip> { _pleasureShuttle, _vaclas });
    }

    [Fact]
    public void TestOptimalShipInNitrogenParticleEnvironment()
    {
        IShip optimalShip = _routingService.DetermineOptimalShip() ?? throw new InvalidOperationException();
        string result = _routingService.ExecuteRouting();

        Assert.Equal(_vaclas, optimalShip);
        Assert.Equal("Succeed", result);
    }
}