namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageDevice.SSD;

public class SSDBuilder : ISSDBuilder
{
    private string _connectionType;
    private int _capacity;
    private double _maxSpeed;
    private double _powerConsumption;

    public SSDBuilder(SSD ssd)
    {
        SSD newSSD = ssd.Clone();
        _connectionType = newSSD.ConnectionType;
        _capacity = newSSD.Capacity;
        _maxSpeed = newSSD.MaxSpeed;
        _powerConsumption = newSSD.PowerConsumption;
    }

    public ISSDBuilder SetConnectionType(string connectionType)
    {
        _connectionType = connectionType;
        return this;
    }

    public ISSDBuilder SetCapacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public ISSDBuilder SetMaxSpeed(double maxSpeed)
    {
        _maxSpeed = maxSpeed;
        return this;
    }

    public ISSDBuilder SetPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public SSD Build()
    {
        return new SSD(_connectionType, _capacity, _maxSpeed, _powerConsumption);
    }
}