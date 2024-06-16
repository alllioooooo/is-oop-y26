using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;

public class BIOSBuilder : IBIOSBuilder
{
    private string _type;
    private string _version;
    private IReadOnlyList<string> _supportedProcessors;

    public BIOSBuilder(BIOS bios)
    {
        BIOS newBios = bios.Clone();
        _type = newBios.Type;
        _version = newBios.Version;
        _supportedProcessors = newBios.SupportedProcessors;
    }

    public IBIOSBuilder SetType(string type)
    {
        _type = type;
        return this;
    }

    public IBIOSBuilder SetVersion(string version)
    {
        _version = version;
        return this;
    }

    public IBIOSBuilder SetSupportedProcessors(IReadOnlyList<string> supportedProcessors)
    {
        _supportedProcessors = supportedProcessors;
        return this;
    }

    public BIOS Build()
    {
        return new BIOS(_type, _version, _supportedProcessors);
    }
}