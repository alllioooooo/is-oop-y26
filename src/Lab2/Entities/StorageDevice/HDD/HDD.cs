namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageDevice.HDD;

public class HDD
{
    public HDD(int capacity, int spindleSpeed, double powerConsumption)
    {
        Capacity = capacity;
        SpindleSpeed = spindleSpeed;
        PowerConsumption = powerConsumption;
    }

    public int Capacity { get; private set; }
    public int SpindleSpeed { get; private set; }
    public double PowerConsumption { get; private set; }

    public HDD Clone()
    {
        return new HDD(Capacity, SpindleSpeed, PowerConsumption);
    }
}