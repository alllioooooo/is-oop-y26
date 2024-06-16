using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageDevice.HDD;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageDevice.SSD;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ValidationModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PersonalComputer;

public class PCBuilder : IPCBuilder
{
    private Motherboard? _motherboard;
    private CPU.CPU? _cpu;
    private CoolingSystem.CoolingSystem? _coolingSystem;
    private GPU.GPU? _gpu;
    private PCCase.PCCase? _pcCase;
    private PowerSupply.PowerSupply? _powerSupply;
    private RAM.RAM? _ram;
    private HDD? _hdd;
    private SSD? _ssd;
    private WiFiAdapter.WiFiAdapter? _wiFiAdapter;

    public PCBuilder(PC pc)
    {
        PC newPc = pc.Clone();
        _motherboard = newPc.Motherboard;
        _cpu = newPc.CPU;
        _coolingSystem = newPc.CoolingSystem;
        _gpu = newPc.GPU;
        _pcCase = newPc.PCCase;
        _powerSupply = newPc.PowerSupply;
        _ram = newPc.RAM;
        _hdd = newPc.HDD;
        _ssd = newPc.SSD;
        _wiFiAdapter = newPc.WiFiAdapter;
    }

    public PCBuilder()
    {
        _motherboard = null;
        _cpu = null;
        _coolingSystem = null;
        _gpu = null;
        _pcCase = null;
        _powerSupply = null;
        _ram = null;
        _hdd = null;
        _ssd = null;
        _wiFiAdapter = null;
    }

    public IPCBuilder SetMotherboard(Motherboard? motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public IPCBuilder SetCPU(CPU.CPU? cpu)
    {
        _cpu = cpu;
        return this;
    }

    public IPCBuilder SetCoolingSystem(CoolingSystem.CoolingSystem? coolingSystem)
    {
        _coolingSystem = coolingSystem;
        return this;
    }

    public IPCBuilder SetGPU(GPU.GPU? gpu)
    {
        _gpu = gpu;
        return this;
    }

    public IPCBuilder SetPCCase(PCCase.PCCase? pcCase)
    {
        _pcCase = pcCase;
        return this;
    }

    public IPCBuilder SetPowerSupply(PowerSupply.PowerSupply? powerSupply)
    {
        _powerSupply = powerSupply;
        return this;
    }

    public IPCBuilder SetRAM(RAM.RAM? ram)
    {
        _ram = ram;
        return this;
    }

    public IPCBuilder SetHDD(HDD? hdd)
    {
        _hdd = hdd;
        return this;
    }

    public IPCBuilder SetSSD(SSD? ssd)
    {
        _ssd = ssd;
        return this;
    }

    public IPCBuilder SetWiFiAdapter(WiFiAdapter.WiFiAdapter? wiFiAdapter)
    {
        _wiFiAdapter = wiFiAdapter;
        return this;
    }

    public PC Build()
    {
        if (_motherboard == null || _cpu == null || _coolingSystem == null || _pcCase == null || _powerSupply == null ||
            _ram == null)
        {
            throw new InvalidOperationException("All required components must be added.");
        }

        var pcModel = new PCModel(_motherboard, _cpu, _coolingSystem, _pcCase, _powerSupply, _ram, _hdd, _ssd, _wiFiAdapter, _gpu);
        var validator = new PCValidator(pcModel);
        IReadOnlyList<CompatibilityResult?> validationResults = validator.ValidateComponents();

        var warnings = new List<string?>();
        foreach (CompatibilityResult? validationResult in validationResults)
        {
            if (validationResult is NotCompatible notCompatible)
            {
                throw new InvalidOperationException("Incompatible components: " + notCompatible.Message);
            }
            else if (validationResult is CompatibleWithWarning compatibleWithWarning)
            {
                warnings.Add(compatibleWithWarning.Message);
            }
        }

        if (warnings.Any())
        {
            string warningMessage = string.Join(Environment.NewLine, warnings);
            throw new InvalidOperationException($"The PC was built, but with warnings: {warningMessage}");
        }

        return new PC(_motherboard, _cpu, _coolingSystem, _pcCase, _powerSupply, _ram, _hdd, _ssd, _wiFiAdapter, _gpu);
    }
}