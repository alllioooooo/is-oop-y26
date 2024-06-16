using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.FuelExchange;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.SpaceWhaleTest;

public class SpaceWhaleTest
{
    private static readonly Route NitrogenParticleRoute = new(new NitrogenParticleEnvironment());

    private readonly IShip _vaclas = new Vaclas();
    private readonly IShip _augur = new Augur();
    private readonly IShip _meredian = new Meredian();

    public SpaceWhaleTest()
    {
        ImpulseEngineFuelPricing.SetPricePerUnit(100);
        JumpEngineFuelPricing.SetPricePerUnit(200);
        NitrogenParticleRoute.AddSegment(new RouteSegment(new List<IObstacle> { new SpaceWhale(1) }, 50));
    }

    [Fact]
    public void TestVaclasInNitrogenParticleEnvironment()
    {
        var routingService = new RoutingService(NitrogenParticleRoute, new List<IShip> { _vaclas });
        string result = routingService.ExecuteRouting();

        Assert.Equal("Destroyed", result);
    }

    [Fact]
    public void TestAugurInNitrogenParticleEnvironment()
    {
        var routingService = new RoutingService(NitrogenParticleRoute, new List<IShip> { _augur });
        string result = routingService.ExecuteRouting();

        Assert.Equal("Shields down", result);
    }

    [Fact]
    public void TestMeredianInNitrogenParticleEnvironment()
    {
        var routingService = new RoutingService(NitrogenParticleRoute, new List<IShip> { _meredian });
        string result = routingService.ExecuteRouting();

        Assert.Equal("Succeed", result);
    }
}