using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageDevice.HDD;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageDevice.SSD;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PersonalComputer;

public class PCModel
{
    public PCModel(
        Motherboard motherboard,
        CPU.CPU cpu,
        CoolingSystem.CoolingSystem coolingSystem,
        PCCase.PCCase pcCase,
        PowerSupply.PowerSupply powerSupply,
        RAM.RAM ram,
        HDD? hdd = null,
        SSD? ssd = null,
        WiFiAdapter.WiFiAdapter? wiFiAdapter = null,
        GPU.GPU? gpu = null)
    {
        Motherboard = motherboard;
        CPU = cpu;
        CoolingSystem = coolingSystem;
        GPU = gpu;
        PCCase = pcCase;
        PowerSupply = powerSupply;
        RAM = ram;
        HDD = hdd;
        SSD = ssd;
        WiFiAdapter = wiFiAdapter;
    }

    public Motherboard Motherboard { get; private set; }

    public CPU.CPU CPU { get; private set; }

    public CoolingSystem.CoolingSystem CoolingSystem { get; private set; }

    public GPU.GPU? GPU { get; private set; }

    public PCCase.PCCase PCCase { get; private set; }

    public PowerSupply.PowerSupply PowerSupply { get; private set; }

    public RAM.RAM RAM { get; private set; }

    public HDD? HDD { get; private set; }

    public SSD? SSD { get; private set; }

    public WiFiAdapter.WiFiAdapter? WiFiAdapter { get; private set; }
}