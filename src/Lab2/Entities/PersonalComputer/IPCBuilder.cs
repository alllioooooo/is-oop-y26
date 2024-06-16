using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageDevice.HDD;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageDevice.SSD;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PersonalComputer;

public interface IPCBuilder
{
    IPCBuilder SetMotherboard(Motherboard? motherboard);
    IPCBuilder SetCPU(CPU.CPU? cpu);
    IPCBuilder SetCoolingSystem(CoolingSystem.CoolingSystem? coolingSystem);
    IPCBuilder SetGPU(GPU.GPU? gpu);
    IPCBuilder SetPCCase(PCCase.PCCase? pcCase);
    IPCBuilder SetPowerSupply(PowerSupply.PowerSupply? powerSupply);
    IPCBuilder SetRAM(RAM.RAM? ram);
    IPCBuilder SetHDD(HDD? hdd);
    IPCBuilder SetSSD(SSD? ssd);
    IPCBuilder SetWiFiAdapter(WiFiAdapter.WiFiAdapter? wiFiAdapter);
    PC Build();
}