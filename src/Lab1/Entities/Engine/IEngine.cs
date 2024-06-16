namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public interface IEngine
{
    double FuelConsumption { get; }
    double FuelNeeded(double distance);
}