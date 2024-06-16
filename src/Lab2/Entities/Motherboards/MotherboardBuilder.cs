namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;

public class MotherboardBuilder : IMotherboardBuilder
{
    private string _socket;
    private int _pcieLines;
    private int _sataPorts;
    private string _chipset;
    private string _supportedDDR;
    private int _ramSlots;
    private string _formFactor;
    private BIOS.BIOS _bios;

    public MotherboardBuilder(Motherboard motherboard)
    {
        Motherboard newMotherboard = motherboard.Clone();
        _socket = newMotherboard.Socket;
        _pcieLines = newMotherboard.PCIeLines;
        _sataPorts = newMotherboard.SATAPorts;
        _chipset = newMotherboard.Chipset;
        _supportedDDR = newMotherboard.SupportedDDR;
        _ramSlots = newMotherboard.RAMSlots;
        _formFactor = newMotherboard.FormFactor;
        _bios = newMotherboard.Bios;
    }

    public IMotherboardBuilder SetSocket(string socket)
    {
        _socket = socket;
        return this;
    }

    public IMotherboardBuilder SetPCIeLines(int pcieLines)
    {
        _pcieLines = pcieLines;
        return this;
    }

    public IMotherboardBuilder SetSATAPorts(int sataPorts)
    {
        _sataPorts = sataPorts;
        return this;
    }

    public IMotherboardBuilder SetChipset(string chipset)
    {
        _chipset = chipset;
        return this;
    }

    public IMotherboardBuilder SetSupportedDDR(string supportedDDR)
    {
        _supportedDDR = supportedDDR;
        return this;
    }

    public IMotherboardBuilder SetRAMSlots(int ramSlots)
    {
        _ramSlots = ramSlots;
        return this;
    }

    public IMotherboardBuilder SetFormFactor(string formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IMotherboardBuilder SetBios(BIOS.BIOS bios)
    {
        _bios = bios;
        return this;
    }

    public Motherboard Build()
    {
        return new Motherboard(_socket, _pcieLines, _sataPorts, _chipset, _supportedDDR, _ramSlots, _formFactor, _bios);
    }
}