using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;

public class Motherboard
{
    public Motherboard(string socket, int pcIeLines, int sataPorts, string chipset, string supportedDdr, int ramSlots, string formFactor, BIOS.BIOS bios)
    {
        Socket = socket;
        PCIeLines = pcIeLines;
        SATAPorts = sataPorts;
        Chipset = chipset;
        SupportedDDR = supportedDdr;
        RAMSlots = ramSlots;
        FormFactor = formFactor;
        Bios = bios;
    }

    public string Socket { get; private set; }
    public int PCIeLines { get; private set; }
    public int SATAPorts { get; private set; }
    public string Chipset { get; private set; }
    public string SupportedDDR { get; private set; }
    public int RAMSlots { get; private set; }
    public string FormFactor { get; private set; }
    public BIOS.BIOS Bios { get; private set; }

    public Motherboard Clone()
    {
        return new Motherboard(Socket, PCIeLines, SATAPorts, Chipset, SupportedDDR, RAMSlots, FormFactor, Bios);
    }

    public CompatibilityResult IsCPUCompatible(CPU.CPU cpu)
    {
        return Socket == cpu.Socket || Bios.SupportedProcessors.Any(name => name == cpu.Name)
            ? new Compatible("Compatible")
            : new NotCompatible("The CPU is not compatible with the motherboard.");
    }
}