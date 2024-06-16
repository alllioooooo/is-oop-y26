namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.XMProfile;

public class XMPBuilder : IXMPBuilder
{
    private string? _timings;
    private double? _voltage;
    private double? _frequency;

    public XMPBuilder(XMP xmp)
    {
        XMP newXMP = xmp.Clone();
        _timings = newXMP.Timings;
        _voltage = newXMP.Voltage;
        _frequency = newXMP.Frequency;
    }

    public IXMPBuilder SetTimings(string? timings)
    {
        _timings = timings;
        return this;
    }

    public IXMPBuilder SetVoltage(double? voltage)
    {
        _voltage = voltage;
        return this;
    }

    public IXMPBuilder SetFrequency(double? frequency)
    {
        _frequency = frequency;
        return this;
    }

    public XMP Build()
    {
        return new XMP(_timings, _voltage, _frequency);
    }
}