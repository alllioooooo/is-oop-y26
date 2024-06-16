using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.HullStrength;

public class HullStrengthClass2 : IHullStrength
{
    private double _damageTaken;

    public bool IsDestroyed { get; private set; }
    public int Level => 2;

    public void TakeDamage(double damage)
    {
        _damageTaken += damage;

        if (_damageTaken is >= 6 * IObstacle.AsteroidMass or >= 3 * IObstacle.MeteoriteMass)
            IsDestroyed = true;
    }

    public void Destroy()
    {
        IsDestroyed = true;
    }
}