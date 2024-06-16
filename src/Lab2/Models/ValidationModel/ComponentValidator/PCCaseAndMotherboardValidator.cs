using Itmo.ObjectOrientedProgramming.Lab2.Entities.PersonalComputer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidationModel.ComponentValidator;

public class PCCaseAndMotherboardValidator : IComponentValidator
{
    public CompatibilityResult? Validate(PCModel pcModel)
    {
        return pcModel.PCCase.IsMotherboardCompatible(pcModel.Motherboard);
    }
}