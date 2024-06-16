namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageDevice.SSD;

public class SSD
{
    public SSD(string connectionType, int capacity, double maxSpeed, double powerConsumption)
    {
        ConnectionType = connectionType;
        Capacity = capacity;
        MaxSpeed = maxSpeed;
        PowerConsumption = powerConsumption;
    }

    public string ConnectionType { get; private set; }
    public int Capacity { get; private set; }
    public double MaxSpeed { get; private set; }
    public double PowerConsumption { get; private set; }

    public SSD Clone()
    {
        return new SSD(ConnectionType, Capacity, MaxSpeed, PowerConsumption);
    }
}