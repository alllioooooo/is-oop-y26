namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.HullStrength;

public interface IHullStrength
{
    public bool IsDestroyed { get; }
    int Level { get; }
    public void TakeDamage(double damage);
    public void Destroy();
}