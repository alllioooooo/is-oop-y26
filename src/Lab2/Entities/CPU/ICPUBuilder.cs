namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;

public interface ICPUBuilder
{
    ICPUBuilder SetName(string name);
    ICPUBuilder SetCoreFrequency(double coreFrequency);
    ICPUBuilder SetNumberOfCores(int numberOfCores);
    ICPUBuilder SetSocket(string socket);
    ICPUBuilder SetIntegratedGPU(bool hasIntegratedGPU);
    ICPUBuilder SetSupportedMemoryFrequencies(int supportedMemoryFrequencies);
    ICPUBuilder SetTDP(int tdp);
    ICPUBuilder SetPowerConsumption(int powerConsumption);
    CPU Build();
}