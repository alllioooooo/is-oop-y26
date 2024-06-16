using Itmo.ObjectOrientedProgramming.Lab2.Entities.PersonalComputer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidationModel.ComponentValidator;

public class MotherboardAndCPUValidator : IComponentValidator
{
    public CompatibilityResult? Validate(PCModel pcModel)
    {
        return pcModel.Motherboard.IsCPUCompatible(pcModel.CPU);
    }
}