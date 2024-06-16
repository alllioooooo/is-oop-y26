using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCCase;

public class PCCaseBuilder : IPCCaseBuilder
{
    private int _maxGpuSize;
    private IReadOnlyList<string> _supportedMotherboardsFormFactor;
    private string _dimensions;

    public PCCaseBuilder(PCCase pcCase)
    {
        PCCase newPCCase = pcCase.Clone();
        _maxGpuSize = newPCCase.MaxGpuSize;
        _supportedMotherboardsFormFactor = newPCCase.SupportedMotherboardsFormFactor;
        _dimensions = newPCCase.Dimensions;
    }

    public IPCCaseBuilder SetMaxGpuSize(int size)
    {
        _maxGpuSize = size;
        return this;
    }

    public IPCCaseBuilder SetSupportedMotherboardsFormFactor(IReadOnlyList<string> supportedMotherboardsFormFactor)
    {
        _supportedMotherboardsFormFactor = supportedMotherboardsFormFactor;
        return this;
    }

    public IPCCaseBuilder SetDimensions(string dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public PCCase Build()
    {
        return new PCCase(_maxGpuSize, _supportedMotherboardsFormFactor, _dimensions);
    }
}