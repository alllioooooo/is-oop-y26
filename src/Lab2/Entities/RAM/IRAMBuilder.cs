using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XMProfile;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;

public interface IRAMBuilder
{
    IRAMBuilder SetSize(int size);
    IRAMBuilder SetJedecSpecs(IReadOnlyList<(int Frequency, double Voltage)>? jedecSpecs);
    IRAMBuilder SetXmpProfiles(IReadOnlyList<XMP>? xmpProfiles);
    IRAMBuilder SetFormFactor(string formFactor);
    IRAMBuilder SetDdrVersion(string ddrVersion);
    IRAMBuilder SetPowerConsumption(double powerConsumption);
    RAM Build();
}