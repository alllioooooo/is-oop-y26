using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public interface IDeflector
{
    bool IsOffline { get; }
    int Level { get; }
    void TakeDamage(IObstacle obstacle);
    public void Destroy();
}