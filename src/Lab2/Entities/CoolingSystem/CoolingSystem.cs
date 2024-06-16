using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;

public class CoolingSystem
{
    public CoolingSystem(string dimensions, IReadOnlyList<string> supportedSockets, int maxTDP)
    {
        Dimensions = dimensions;
        SupportedSockets = supportedSockets;
        MaxTDP = maxTDP;
    }

    public string Dimensions { get; private set; }
    public IReadOnlyList<string> SupportedSockets { get; private set; }
    public int MaxTDP { get; private set; }

    public CoolingSystem Clone()
    {
        return new CoolingSystem(Dimensions, SupportedSockets, MaxTDP);
    }

    public CompatibilityResult IsCPUCompatible(CPU.CPU cpu)
    {
        if (cpu.TDP > MaxTDP)
        {
            if (cpu.TDP - MaxTDP < 50)
            {
                return new CompatibleWithWarning("Disclaimer of warranties.");
            }

            return new NotCompatible("The CPU is not compatible with the cooling system.");
        }

        return new Compatible("Compatible");
    }
}