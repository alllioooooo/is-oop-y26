using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCCase;

public class PCCase
{
    public PCCase(int maxGpuSize, IReadOnlyList<string> supportedMotherboardsFormFactor, string dimensions)
    {
        MaxGpuSize = maxGpuSize;
        SupportedMotherboardsFormFactor = supportedMotherboardsFormFactor;
        Dimensions = dimensions;
    }

    public int MaxGpuSize { get; private set; }
    public IReadOnlyList<string> SupportedMotherboardsFormFactor { get; private set; }
    public string Dimensions { get; private set; }

    public PCCase Clone()
    {
        return new PCCase(MaxGpuSize, SupportedMotherboardsFormFactor, Dimensions);
    }

    public CompatibilityResult IsGPUCompatible(GPU.GPU gpu)
    {
        return MaxGpuSize >= gpu.Dimensions.Height || MaxGpuSize >= gpu.Dimensions.Width
            ? new Compatible("Compatible")
            : new NotCompatible("The GPU is not compatible with the PC case.");
    }

    public CompatibilityResult IsMotherboardCompatible(Motherboard motherboard)
    {
        return SupportedMotherboardsFormFactor.Any(formFactor => formFactor == motherboard.FormFactor)
            ? new Compatible("Compatible")
            : new NotCompatible("The motherboard is not compatible with the PC case.");
    }
}