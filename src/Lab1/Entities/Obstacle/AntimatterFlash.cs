namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class AntimatterFlash : IObstacle
{
    public double DamageCoefficient => 0;

    public bool IsDestroyed()
    {
        return false;
    }
}