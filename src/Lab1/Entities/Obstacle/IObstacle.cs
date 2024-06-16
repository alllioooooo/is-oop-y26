namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public interface IObstacle
{
    public const double MeteoriteMass = 3.0;
    public const double AsteroidMass = 6.0;
    double DamageCoefficient { get; }
    bool IsDestroyed();
}