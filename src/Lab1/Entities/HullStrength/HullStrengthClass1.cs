using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.HullStrength;

public class HullStrengthClass1 : IHullStrength
{
    private double _damageTaken;

    public bool IsDestroyed { get; private set; }
    public int Level => 1;

    public void TakeDamage(double damage)
    {
        _damageTaken += damage;

        if (_damageTaken >= IObstacle.AsteroidMass)
            IsDestroyed = true;
    }

    public void Destroy()
    {
        IsDestroyed = true;
    }
}