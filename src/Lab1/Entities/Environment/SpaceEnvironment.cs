using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;

public class SpaceEnvironment : IEnvironment
{
    public bool AddObstacle(IObstacle obstacle)
    {
        return obstacle is Meteorite or Asteroid;
    }
}
