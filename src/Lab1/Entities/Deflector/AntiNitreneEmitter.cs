using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class AntiNitreneEmitter : IDeflector
{
    public AntiNitreneEmitter()
        : this(false)
    {
    }

    public AntiNitreneEmitter(bool isOffline)
    {
        IsOffline = isOffline;
    }

    public int Level => 0;

    public bool IsOffline { get; private set; }

    public void TakeDamage(IObstacle obstacle)
    {
        if (obstacle is SpaceWhale)
        {
            return;
        }
    }

    public void Destroy()
    {
        IsOffline = true;
    }
}