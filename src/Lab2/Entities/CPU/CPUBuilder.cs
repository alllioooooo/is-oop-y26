namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;

public class CPUBuilder : ICPUBuilder
{
    private string _name;
    private double _coreFrequency;
    private int _numberOfCores;
    private string _socket;
    private bool _hasIntegratedGPU;
    private int _supportedMemoryFrequencies;
    private int _tdp;
    private int _powerConsumption;

    public CPUBuilder(CPU cpu)
    {
        CPU newCPU = cpu.Clone();
        _name = newCPU.Name;
        _coreFrequency = newCPU.CoreFrequency;
        _numberOfCores = newCPU.NumberOfCores;
        _socket = newCPU.Socket;
        _hasIntegratedGPU = newCPU.HasIntegratedGPU;
        _supportedMemoryFrequencies = newCPU.SupportedMemoryFrequencies;
        _tdp = newCPU.TDP;
        _powerConsumption = newCPU.PowerConsumption;
    }

    public ICPUBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public ICPUBuilder SetCoreFrequency(double coreFrequency)
    {
        _coreFrequency = coreFrequency;
        return this;
    }

    public ICPUBuilder SetNumberOfCores(int numberOfCores)
    {
        _numberOfCores = numberOfCores;
        return this;
    }

    public ICPUBuilder SetSocket(string socket)
    {
        _socket = socket;
        return this;
    }

    public ICPUBuilder SetIntegratedGPU(bool hasIntegratedGPU)
    {
        _hasIntegratedGPU = hasIntegratedGPU;
        return this;
    }

    public ICPUBuilder SetSupportedMemoryFrequencies(int supportedMemoryFrequencies)
    {
        _supportedMemoryFrequencies = supportedMemoryFrequencies;
        return this;
    }

    public ICPUBuilder SetTDP(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public ICPUBuilder SetPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public CPU Build()
    {
        return new CPU(_name, _coreFrequency, _numberOfCores, _socket, _hasIntegratedGPU, _supportedMemoryFrequencies, _tdp, _powerConsumption);
    }
}