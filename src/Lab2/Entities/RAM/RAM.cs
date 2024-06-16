using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XMProfile;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;

public class RAM
{
    public RAM(int size, IReadOnlyList<(int Frequency, double Voltage)>? jedecSpecs, IReadOnlyList<XMP>? xmpProfiles, string formFactor, string ddrVersion, double powerConsumption)
    {
        Size = size;
        JedecSpecs = jedecSpecs;
        XmpProfiles = xmpProfiles;
        FormFactor = formFactor;
        DdrVersion = ddrVersion;
        PowerConsumption = powerConsumption;
    }

    public int Size { get; }
    public IReadOnlyList<(int Frequency, double Voltage)>? JedecSpecs { get; }
    public IReadOnlyList<XMP>? XmpProfiles { get; }
    public string FormFactor { get; }
    public string DdrVersion { get; }
    public double PowerConsumption { get; }

    public RAM Clone()
    {
        return new RAM(Size, JedecSpecs, XmpProfiles, FormFactor, DdrVersion, PowerConsumption);
    }

    public CompatibilityResult IsMotherboardCompatible(Motherboard motherboard)
    {
        if (DdrVersion == motherboard.SupportedDDR)
            return new Compatible("Compatible");

        if (XmpProfiles != null && XmpProfiles.Any(xmpProfile => xmpProfile.IsCompatibleWith(motherboard.Chipset)))
            return new Compatible("Compatible");

        return new NotCompatible("The RAM is not compatible with the motherboard.");
    }

    public CompatibilityResult IsCoolingSystemCompatible(CoolingSystem.CoolingSystem coolingSystem)
    {
        if (coolingSystem.MaxTDP >= PowerConsumption)
        {
            return new Compatible("Compatible");
        }
        else if (coolingSystem.MaxTDP >= PowerConsumption - 5)
        {
            return new CompatibleWithWarning("The cooling system is barely compatible with the RAM. Consider upgrading the cooling system.");
        }
        else
        {
            return new NotCompatible("The cooling system is not compatible with the RAM.");
        }
    }
}