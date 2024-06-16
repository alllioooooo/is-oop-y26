using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCCase;

public interface IPCCaseBuilder
{
    IPCCaseBuilder SetMaxGpuSize(int size);
    IPCCaseBuilder SetSupportedMotherboardsFormFactor(IReadOnlyList<string> supportedMotherboardsFormFactor);
    IPCCaseBuilder SetDimensions(string dimensions);
    PCCase Build();
}
