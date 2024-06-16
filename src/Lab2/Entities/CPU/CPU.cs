namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;

public class CPU
{
    public CPU(string name, double coreFrequency, int numberOfCores, string socket, bool hasIntegratedGPU, int supportedMemoryFrequencies, int tdp, int powerConsumption)
    {
        Name = name;
        CoreFrequency = coreFrequency;
        NumberOfCores = numberOfCores;
        Socket = socket;
        HasIntegratedGPU = hasIntegratedGPU;
        SupportedMemoryFrequencies = supportedMemoryFrequencies;
        TDP = tdp;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; private set; }
    public double CoreFrequency { get; private set; }
    public int NumberOfCores { get; private set; }
    public string Socket { get; private set; }
    public bool HasIntegratedGPU { get; private set; }
    public int SupportedMemoryFrequencies { get; private set; }
    public int TDP { get; private set; }
    public int PowerConsumption { get; private set; }

    public CPU Clone()
    {
        return new CPU(Name, CoreFrequency, NumberOfCores, Socket, HasIntegratedGPU, SupportedMemoryFrequencies, TDP, PowerConsumption);
    }
}