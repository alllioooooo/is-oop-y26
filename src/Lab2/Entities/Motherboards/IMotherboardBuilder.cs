namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;

public interface IMotherboardBuilder
{
    IMotherboardBuilder SetSocket(string socket);
    IMotherboardBuilder SetPCIeLines(int pcieLines);
    IMotherboardBuilder SetSATAPorts(int sataPorts);
    IMotherboardBuilder SetChipset(string chipset);
    IMotherboardBuilder SetSupportedDDR(string supportedDDR);
    IMotherboardBuilder SetRAMSlots(int ramSlots);
    IMotherboardBuilder SetFormFactor(string formFactor);
    IMotherboardBuilder SetBios(BIOS.BIOS bios);
    Motherboard Build();
}