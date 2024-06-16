using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XMProfile;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;

public class RAMBuilder : IRAMBuilder
{
    private int _size;
    private IReadOnlyList<(int Frequency, double Voltage)>? _jedecSpecs;
    private IReadOnlyList<XMP>? _xmpProfiles;
    private string _formFactor;
    private string _ddrVersion;
    private double _powerConsumption;

    public RAMBuilder(RAM ram)
    {
        RAM newRAM = ram.Clone();
        _size = newRAM.Size;
        _jedecSpecs = newRAM.JedecSpecs;
        _xmpProfiles = newRAM.XmpProfiles;
        _formFactor = newRAM.FormFactor;
        _ddrVersion = newRAM.DdrVersion;
        _powerConsumption = newRAM.PowerConsumption;
    }

    public IRAMBuilder SetSize(int size)
    {
        _size = size;
        return this;
    }

    public IRAMBuilder SetJedecSpecs(IReadOnlyList<(int Frequency, double Voltage)>? jedecSpecs)
    {
        _jedecSpecs = jedecSpecs;
        return this;
    }

    public IRAMBuilder SetXmpProfiles(IReadOnlyList<XMP>? xmpProfiles)
    {
        _xmpProfiles = xmpProfiles;
        return this;
    }

    public IRAMBuilder SetFormFactor(string formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IRAMBuilder SetDdrVersion(string ddrVersion)
    {
        _ddrVersion = ddrVersion;
        return this;
    }

    public IRAMBuilder SetPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public RAM Build()
    {
        return new RAM(_size, _jedecSpecs, _xmpProfiles, _formFactor, _ddrVersion, _powerConsumption);
    }
}