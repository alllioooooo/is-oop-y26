namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GPU;

public interface IGPUBuilder
{
    IGPUBuilder SetDimensions(double height, double width);
    IGPUBuilder SetVideoMemory(int videoMemory);
    IGPUBuilder SetPCIeVersion(string pcieVersion);
    IGPUBuilder SetChipFrequency(double chipFrequency);
    IGPUBuilder SetPowerConsumption(double powerConsumption);
    GPU Build();
}