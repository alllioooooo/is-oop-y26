using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;

public class BIOS
{
    public BIOS(string type, string version, IReadOnlyList<string> supportedProcessors)
    {
        Type = type;
        Version = version;
        SupportedProcessors = supportedProcessors;
    }

    public string Type { get; private set; }
    public string Version { get; private set; }
    public IReadOnlyList<string> SupportedProcessors { get; private set; }

    public BIOS Clone()
    {
        return new BIOS(Type, Version, new List<string>(SupportedProcessors));
    }

    public bool IsProcessorSupported(string processorName)
    {
        return SupportedProcessors.Contains(processorName);
    }
}