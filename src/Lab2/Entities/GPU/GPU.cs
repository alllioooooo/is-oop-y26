namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GPU;

public class GPU
{
    public GPU((double Height, double Width) dimensions, int videoMemory, string pcieVersion, double chipFrequency, double powerConsumption)
    {
        Dimensions = dimensions;
        VideoMemory = videoMemory;
        PCIeVersion = pcieVersion;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public (double Height, double Width) Dimensions { get; private set; }

    public int VideoMemory { get; private set; }

    public string PCIeVersion { get; private set; }

    public double ChipFrequency { get; private set; }

    public double PowerConsumption { get; private set; }

    public GPU Clone()
    {
        return new GPU(Dimensions, VideoMemory, PCIeVersion, ChipFrequency, PowerConsumption);
    }
}