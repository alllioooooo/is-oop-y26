namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerSupply;

public interface IPowerSupplyBuilder
{
    IPowerSupplyBuilder SetPeakLoad(int peakLoad);
    PowerSupply Build();
}