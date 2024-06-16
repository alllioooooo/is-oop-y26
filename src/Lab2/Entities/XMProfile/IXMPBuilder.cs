namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.XMProfile;

public interface IXMPBuilder
{
    IXMPBuilder SetTimings(string? timings);
    IXMPBuilder SetVoltage(double? voltage);
    IXMPBuilder SetFrequency(double? frequency);
    XMP Build();
}