using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class DeflectorClass2 : IDeflector
{
    private int _asteroidCount;
    private int _meteorCount;

    public bool IsOffline { get; private set; }
    public int Level => 2;

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
        }

        if (_asteroidCount >= 10 || _meteorCount >= 3)
        {
            IsOffline = true;
        }
    }

    public void Destroy()
    {
        IsOffline = true;
    }
}