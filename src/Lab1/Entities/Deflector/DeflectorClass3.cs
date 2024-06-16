using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class DeflectorClass3 : IDeflector
{
    private int _asteroidCount;
    private int _meteorCount;
    private int _spaceWhaleCount;

    public bool IsOffline { get; private set; }
    public int Level => 3;

    public void TakeDamage(IObstacle obstacle)
    {
        switch (obstacle)
        {
            case Asteroid:
                _asteroidCount++;
                break;
            case Meteorite:
                _meteorCount++;
                break;
            case SpaceWhale:
                _spaceWhaleCount++;
                break;
        }

        if (_asteroidCount >= 40 || _meteorCount >= 10 || _spaceWhaleCount >= 1)
        {
            IsOffline = true;
        }
    }

    public void Destroy()
    {
        IsOffline = true;
    }
}