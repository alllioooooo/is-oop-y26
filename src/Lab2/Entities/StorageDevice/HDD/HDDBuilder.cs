namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageDevice.HDD;

public class HDDBuilder : IHDDBuilder
{
    private int _capacity;
    private int _spindleSpeed;
    private double _powerConsumption;

    public HDDBuilder(HDD hdd)
    {
        HDD newHDD = hdd.Clone();
        _capacity = newHDD.Capacity;
        _spindleSpeed = newHDD.SpindleSpeed;
        _powerConsumption = newHDD.PowerConsumption;
    }

    public IHDDBuilder SetCapacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public IHDDBuilder SetSpindleSpeed(int spindleSpeed)
    {
        _spindleSpeed = spindleSpeed;
        return this;
    }

    public IHDDBuilder SetPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public HDD Build()
    {
        return new HDD(_capacity, _spindleSpeed, _powerConsumption);
    }
}