namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class Meteorite : IObstacle
{
    private readonly double _mass;

    protected Meteorite()
    {
        _mass = IObstacle.MeteoriteMass;
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