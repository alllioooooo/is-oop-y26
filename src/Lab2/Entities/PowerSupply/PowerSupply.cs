using Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageDevice.HDD;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageDevice.SSD;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerSupply;

public class PowerSupply
{
    public PowerSupply(int peakLoad)
    {
        PeakLoad = peakLoad;
    }

    public int PeakLoad { get; private set; }

    public PowerSupply Clone()
    {
        return new PowerSupply(PeakLoad);
    }

    public CompatibilityResult IsPowerSupplyCompatible(CPU.CPU cpu, RAM.RAM ram, GPU.GPU? gpu, SSD? ssd, HDD? hdd, WiFiAdapter.WiFiAdapter? wiFiAdapter)
    {
        double totalPowerConsumption = cpu.PowerConsumption + ram.PowerConsumption + (gpu?.PowerConsumption ?? 0) +
                                       (ssd?.PowerConsumption ?? 0) + (hdd?.PowerConsumption ?? 0) + (wiFiAdapter?.PowerConsumption ?? 0);

        return PeakLoad <= totalPowerConsumption
            ? new NotCompatible("The power supply is not compatible with the other components.")
            : new Compatible("Compatible");
    }
}