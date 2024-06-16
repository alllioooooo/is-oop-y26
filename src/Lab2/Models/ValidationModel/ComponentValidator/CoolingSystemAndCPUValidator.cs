using Itmo.ObjectOrientedProgramming.Lab2.Entities.PersonalComputer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidationModel.ComponentValidator;

public class CoolingSystemAndCPUValidator : IComponentValidator
{
    public CompatibilityResult? Validate(PCModel pcModel)
    {
        CompatibilityResult result = pcModel.CoolingSystem.IsCPUCompatible(pcModel.CPU);

        return result;
    }
}