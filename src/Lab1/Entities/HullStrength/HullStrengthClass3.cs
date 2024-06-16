using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.HullStrength;

public class HullStrengthClass3 : IHullStrength
{
    private double _damageTaken;

    public bool IsDestroyed { get; private set; }
    public int Level => 3;

    public void TakeDamage(double damage)
    {
        _damageTaken += damage;

        if (_damageTaken is >= 20 * IObstacle.AsteroidMass or >= 10 * IObstacle.MeteoriteMass)
            IsDestroyed = true;
    }

    public void Destroy()
    {
        IsDestroyed = true;
    }
}