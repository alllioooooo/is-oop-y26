namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class Asteroid : IObstacle
{
    private readonly double _mass;

    protected Asteroid()
    {
        _mass = IObstacle.AsteroidMass;
        DamageCoefficient = CalculateDamage();
    }

    public double DamageCoefficient { get; }

    public bool IsDestroyed()
    {
        return _mass < 100;
    }

    private double CalculateDamage()
    {
        return _mass * 0.1;
    }
}