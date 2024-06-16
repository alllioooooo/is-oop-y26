namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GPU;

public class GPUBuilder : IGPUBuilder
{
    private (double Height, double Width) _dimensions;
    private int _videoMemory;
    private string _pcieVersion;
    private double _chipFrequency;
    private double _powerConsumption;

    public GPUBuilder(GPU gpu)
    {
        GPU newGPU = gpu.Clone();
        _dimensions = newGPU.Dimensions;
        _videoMemory = newGPU.VideoMemory;
        _pcieVersion = newGPU.PCIeVersion;
        _chipFrequency = newGPU.ChipFrequency;
        _powerConsumption = newGPU.PowerConsumption;
    }

    public IGPUBuilder SetDimensions(double height, double width)
    {
        _dimensions = (height, width);
        return this;
    }

    public IGPUBuilder SetVideoMemory(int videoMemory)
    {
        _videoMemory = videoMemory;
        return this;
    }

    public IGPUBuilder SetPCIeVersion(string pcieVersion)
    {
        _pcieVersion = pcieVersion;
        return this;
    }

    public IGPUBuilder SetChipFrequency(double chipFrequency)
    {
        _chipFrequency = chipFrequency;
        return this;
    }

    public IGPUBuilder SetPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public GPU Build()
    {
        return new GPU(_dimensions, _videoMemory, _pcieVersion, _chipFrequency, _powerConsumption);
    }
}