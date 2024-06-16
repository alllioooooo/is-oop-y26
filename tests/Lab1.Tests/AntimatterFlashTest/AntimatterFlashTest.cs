using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.FuelExchange;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.AntimatterFlashTest;

public class AntimatterFlashTest
{
    private static readonly Route Route = new(new DenseSpaceEnvironment());

    private readonly IShip _vaclasWithoutDeflector = new Vaclas();
    private readonly IShip _vaclasWithPhotonDeflector = new Vaclas(new PhotonDeflectorDecorator(new DeflectorClass1()));

    public AntimatterFlashTest()
    {
        ImpulseEngineFuelPricing.SetPricePerUnit(100);
        JumpEngineFuelPricing.SetPricePerUnit(200);
        Route.AddSegment(new RouteSegment(new List<IObstacle> { new AntimatterFlash() }, 100));
    }

    [Fact]
    public void TestVaclasWithoutDeflectorImpact()
    {
        var routingService = new RoutingService(Route, new List<IShip> { _vaclasWithoutDeflector });
        string result = routingService.ExecuteRouting();
        Assert.Equal("Crew dead", result);
    }

    [Fact]
    public void TestVaclasWithPhotonDeflectorImpact()
    {
        var routingService = new RoutingService(Route, new List<IShip> { _vaclasWithPhotonDeflector });
        string result = routingService.ExecuteRouting();
        Assert.Equal("Succeed", result);
    }
}