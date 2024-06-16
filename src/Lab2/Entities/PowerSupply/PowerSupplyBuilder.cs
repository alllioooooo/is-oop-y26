namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerSupply;

public class PowerSupplyBuilder : IPowerSupplyBuilder
{
    private int _peakLoad;

    public PowerSupplyBuilder(PowerSupply powerSupply)
    {
        PowerSupply newPowerSupply = powerSupply.Clone();
        _peakLoad = newPowerSupply.PeakLoad;
    }

    public IPowerSupplyBuilder SetPeakLoad(int peakLoad)
    {
        _peakLoad = peakLoad;
        return this;
    }

    public PowerSupply Build()
    {
        return new PowerSupply(_peakLoad);
    }
}