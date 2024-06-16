namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageDevice.SSD;

public interface ISSDBuilder
{
    ISSDBuilder SetConnectionType(string connectionType);
    ISSDBuilder SetCapacity(int capacity);
    ISSDBuilder SetMaxSpeed(double maxSpeed);
    ISSDBuilder SetPowerConsumption(double powerConsumption);
    SSD Build();
}