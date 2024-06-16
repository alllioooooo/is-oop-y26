using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class RouteSegment
{
    private readonly List<IObstacle> _obstacles;

    public RouteSegment(IEnumerable<IObstacle> obstacles, double length)
    {
        _obstacles = obstacles.ToList();
        Length = length;
    }

    public IEnumerable<IObstacle> Obstacles => _obstacles;

    public double Length { get; }

    public double CalculateSegmentDamage()
    {
        return _obstacles.Sum(obstacle => obstacle.DamageCoefficient);
    }
}