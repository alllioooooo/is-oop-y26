namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageDevice.HDD;

public interface IHDDBuilder
{
    IHDDBuilder SetCapacity(int capacity);
    IHDDBuilder SetSpindleSpeed(int spindleSpeed);
    IHDDBuilder SetPowerConsumption(double powerConsumption);
    HDD Build();
}