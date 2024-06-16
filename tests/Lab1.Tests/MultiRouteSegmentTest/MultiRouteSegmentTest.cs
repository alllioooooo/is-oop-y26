using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.FuelExchange;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.MultiRouteSegmentTest;

public class MultiRouteSegmentTest
{
    private static readonly Route Route1 = new(new DenseSpaceEnvironment());
    private static readonly Route Route2 = new(new NitrogenParticleEnvironment());
    private readonly List<Route> _routes = new() { Route1, Route2 };
    private readonly IShip _meredian = new Meredian(new PhotonDeflectorDecorator(new DeflectorClass2()));

    public MultiRouteSegmentTest()
    {
        ImpulseEngineFuelPricing.SetPricePerUnit(100);
        JumpEngineFuelPricing.SetPricePerUnit(200);

        Route1.AddSegment(new RouteSegment(new List<IObstacle> { new AntimatterFlash() }, 100));
        Route2.AddSegment(new RouteSegment(new List<IObstacle> { new SpaceWhale(1) }, 50));
    }

    [Fact]
    public void TestMeredianThroughMultipleEnvironments()
    {
        foreach (Route route in _routes)
        {
            var routingService = new RoutingService(route, new List<IShip> { _meredian });
            string result = routingService.ExecuteRouting();

            Assert.Equal("Succeed", result);
        }
    }
}