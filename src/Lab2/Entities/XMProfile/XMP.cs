namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.XMProfile;

public class XMP
{
    public XMP(string? timings, double? voltage, double? frequency)
    {
        Timings = timings;
        Voltage = voltage;
        Frequency = frequency;
    }

    public string? Timings { get; private set; }
    public double? Voltage { get; private set; }
    public double? Frequency { get; private set; }

    public XMP Clone()
    {
        return new XMP(Timings, Voltage, Frequency);
    }

    public bool IsCompatibleWith(string chipset)
    {
        if (chipset == Timings)
        {
            return true;
        }

        return false;
    }
}