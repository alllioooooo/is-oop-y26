using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;

public class CoolingSystemBuilder : ICoolingSystemBuilder
{
    private string _dimensions;
    private IReadOnlyList<string> _supportedSockets;
    private int _maxTDP;

    public CoolingSystemBuilder(CoolingSystem coolingSystem)
    {
        CoolingSystem newCoolingSystem = coolingSystem.Clone();
        _dimensions = newCoolingSystem.Dimensions;
        _supportedSockets = newCoolingSystem.SupportedSockets;
        _maxTDP = newCoolingSystem.MaxTDP;
    }

    public ICoolingSystemBuilder SetDimensions(string dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public ICoolingSystemBuilder SetSupportedSockets(IReadOnlyList<string> supportedSockets)
    {
        _supportedSockets = supportedSockets;
        return this;
    }

    public ICoolingSystemBuilder SetMaxTDP(int maxTDP)
    {
        _maxTDP = maxTDP;
        return this;
    }

    public CoolingSystem Build()
    {
        return new CoolingSystem(_dimensions, _supportedSockets, _maxTDP);
    }
}