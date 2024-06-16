namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class SpaceWhale : IObstacle
{
    private readonly int _collisionCount;

    public SpaceWhale(int collisionCount)
    {
        _collisionCount = collisionCount;
        DamageCoefficient = 0;
    }

    public double DamageCoefficient { get; }

    public bool IsDestroyed()
    {
        return _collisionCount <= 1;
    }
}