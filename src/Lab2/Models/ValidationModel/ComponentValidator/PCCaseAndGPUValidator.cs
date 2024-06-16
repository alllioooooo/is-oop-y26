using Itmo.ObjectOrientedProgramming.Lab2.Entities.PersonalComputer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidationModel.ComponentValidator;

public class PCCaseAndGPUValidator : IComponentValidator
{
    public CompatibilityResult? Validate(PCModel pcModel)
    {
        if (pcModel.GPU == null)
        {
            return null;
        }

        return pcModel.PCCase.IsGPUCompatible(pcModel.GPU);
    }
}