using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GPU;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCCase;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PersonalComputer;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageDevice.SSD;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.SuccessfulBuildWithCompatiblePartsTest;

public class SuccessfulBuildWithCompatiblePartsTest
{
    private readonly PC _pc;
    private readonly ComponentRepositoryService _componentRepository;

    public SuccessfulBuildWithCompatiblePartsTest()
    {
        _componentRepository = new ComponentRepositoryService();

        var cpu = _componentRepository.GetComponent("INTEL Core i3 10100F") as CPU;
        Assert.NotNull(cpu);

        var gpu = _componentRepository.GetComponent("Gigabyte GeForce GTX 1650") as GPU;
        Assert.NotNull(gpu);

        var ram = _componentRepository.GetComponent("ADATA XPG GAMMIX D10") as RAM;
        Assert.NotNull(ram);

        var motherboard = _componentRepository.GetComponent("GIGABYTE H510M H") as Motherboard;
        Assert.NotNull(motherboard);

        var ssd = _componentRepository.GetComponent("Kingston NV2") as SSD;
        Assert.NotNull(ssd);

        var coolingSystem = _componentRepository.GetComponent("ID-Cooling DK-03i RGB") as CoolingSystem;
        Assert.NotNull(coolingSystem);

        var powerSupply = _componentRepository.GetComponent("Deepcool PX1000G") as PowerSupply;
        Assert.NotNull(powerSupply);

        var pcCase = _componentRepository.GetComponent("AEROCOOL CYLON MINI") as PCCase;
        Assert.NotNull(pcCase);

        var builder = new PCBuilder();
        _pc = builder
            .SetCPU(cpu)
            .SetGPU(gpu)
            .SetRAM(ram)
            .SetMotherboard(motherboard)
            .SetSSD(ssd)
            .SetCoolingSystem(coolingSystem)
            .SetPowerSupply(powerSupply)
            .SetPCCase(pcCase)
            .Build();
    }

    [Fact]
    public void TestPCIsNotNullAfterSuccessfulBuild()
    {
        Assert.NotNull(_pc);
    }
}