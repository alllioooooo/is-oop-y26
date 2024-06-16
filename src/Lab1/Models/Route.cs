using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Route
{
    private readonly IEnvironment _environment;
    private readonly List<RouteSegment> _segments = new List<RouteSegment>();

    public Route(IEnvironment environment)
    {
        _environment = environment;
    }

    public IEnvironment Environment => _environment;

    public IEnumerable<RouteSegment> Segments => _segments.AsReadOnly();

    public bool HasAntimatterFlash()
    {
        return Segments.Any(segment => segment.Obstacles.OfType<AntimatterFlash>().Any());
    }

    public void AddSegment(RouteSegment segment)
    {
        if (segment.Obstacles.Any(obstacle => !_environment.AddObstacle(obstacle)))
        {
            throw new InvalidOperationException("Cannot add obstacle to environment");
        }

        _segments.Add(segment);
    }

    public double CalculateTotalDamage()
    {
        return _segments.Sum(segment => segment.CalculateSegmentDamage());
    }

    public double CalculateTotalLength()
    {
        return _segments.Sum(segment => segment.Length);
    }
}