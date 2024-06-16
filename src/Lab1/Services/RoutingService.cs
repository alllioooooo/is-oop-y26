using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class RoutingService
{
    private readonly List<IShip> _ships;
    private readonly Route _route;

    public RoutingService(Route route, IEnumerable<IShip>? ships)
    {
        _route = route ?? throw new ArgumentNullException(nameof(route));
        _ships = ships?.ToList() ?? throw new ArgumentNullException(nameof(ships));
    }

    public static double FlightCost(IShip ship, Route route)
    {
        IEnumerable<RouteSegment> segments = route.Segments;

        double totalFuelNeeded = segments.Select(segment => segment.Length).Aggregate<double, double>(
            0,
            (current, segmentLength) => current + ship.ImpulseEngine.FuelNeeded(segmentLength));

        return totalFuelNeeded;
    }

    public string ExecuteRouting()
    {
        IShip? optimalShip = DetermineOptimalShip();

        if (AntimatterFlashEncountered() && optimalShip?.Deflector is not PhotonDeflectorDecorator)
            return "Crew dead";

        if (SpaceWhaleEncountered())
        {
            if (optimalShip?.HullStrength.Level > 2)
                return "Shields down";

            if (optimalShip?.AntiNitreneEmitter != null)
            {
                return "Succeed";
            }
        }

        return RouteShip(optimalShip);
    }

    public IShip? DetermineOptimalShip()
    {
        double routeLength = _route.CalculateTotalLength();

        var viableShips = _ships
            .Where(ship => !ship.HullStrength.IsDestroyed)
            .ToList();

        foreach (IShip? ship in viableShips.ToList())
        {
            bool canMove = ship.JumpEngine?.CanJump(routeLength) ?? false;

            if (!canMove)
            {
                canMove = ship.ImpulseEngine.CanMove(routeLength);
            }

            if (!canMove)
            {
                ship.HullStrength.Destroy();
                viableShips.Remove(ship);
            }
            else
            {
                double potentialDamage = CalculatePotentialDamage();
                ship.HullStrength.TakeDamage(potentialDamage);
            }
        }

        if (!viableShips.Any())
            return null;

        return viableShips
            .OrderByDescending(ship => ship.Deflector != null)
            .ThenBy(ship => FlightCost(ship, _route))
            .ThenByDescending(ship => ship.HullStrength.Level)
            .FirstOrDefault();
    }

    private static string RouteShip(IShip? ship)
    {
        if (ship == null)
        {
            return "Destroyed";
        }

        if (ship.HullStrength.IsDestroyed)
        {
            return "Destroyed";
        }

        return "Succeed";
    }

    private bool AntimatterFlashEncountered()
    {
        return _route.HasAntimatterFlash();
    }

    private bool SpaceWhaleEncountered()
    {
        IShip? optimalShip = DetermineOptimalShip();

        bool whaleEncountered =
            _route.Segments.Any(segment => segment.Obstacles.Any(obstacle => obstacle is SpaceWhale));

        if (!whaleEncountered) return false;

        if (optimalShip?.AntiNitreneEmitter != null)
        {
            return false;
        }

        if (optimalShip?.HullStrength.Level > 1)
        {
            optimalShip?.HullStrength.Destroy();
            return true;
        }

        optimalShip?.HullStrength.Destroy();
        return true;
    }

    private IShip? DetermineCheapestShip()
    {
        return _ships.MinBy(ship => RoutingService.FlightCost(ship, _route));
    }

    private double CalculatePotentialDamage()
    {
        return _route.CalculateTotalDamage();
    }
}