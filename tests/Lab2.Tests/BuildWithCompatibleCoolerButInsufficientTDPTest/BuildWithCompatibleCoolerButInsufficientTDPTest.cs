using System;
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

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.BuildWithCompatibleCoolerButInsufficientTDPTest;

public class BuildWithCompatibleCoolerButInsufficientTDPTest
{
    private readonly PCBuilder _builder;
    private readonly ComponentRepositoryService _componentRepository;

    public BuildWithCompatibleCoolerButInsufficientTDPTest()
    {
        _componentRepository = new ComponentRepositoryService();

        var ram = _componentRepository.GetComponent("ADATA XPG GAMMIX D10") as RAM;
        Assert.NotNull(ram);

        var ramBuilder = new RAMBuilder(ram);
        ram = ramBuilder
            .SetPowerConsumption(224)
            .Build();

        _builder = new PCBuilder();
        _builder
            .SetCPU(_componentRepository.GetComponent("INTEL Core i3 10100F") as CPU)
            .SetGPU(_componentRepository.GetComponent("Gigabyte GeForce GTX 1650") as GPU)
            .SetRAM(ram)
            .SetMotherboard(_componentRepository.GetComponent("GIGABYTE H510M H") as Motherboard)
            .SetSSD(_componentRepository.GetComponent("Kingston NV2") as SSD)
            .SetCoolingSystem(_componentRepository.GetComponent("ID-Cooling DK-03i RGB") as CoolingSystem)
            .SetPowerSupply(_componentRepository.GetComponent("Deepcool PX1000G") as PowerSupply)
            .SetPCCase(_componentRepository.GetComponent("AEROCOOL CYLON MINI") as PCCase);
    }

    [Fact]
    public void TestBuildWithCompatibleCoolerButInsufficientTDP()
    {
        try
        {
            PC pc = _builder.Build();
            Assert.Fail("Expected InvalidOperationException due to insufficient TDP, but got none.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.Contains("The cooling system is barely compatible with the RAM. Consider upgrading the cooling system.", ex.Message, StringComparison.OrdinalIgnoreCase);
        }
    }
}