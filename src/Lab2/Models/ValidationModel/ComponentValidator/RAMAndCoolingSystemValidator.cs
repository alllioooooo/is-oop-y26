using Itmo.ObjectOrientedProgramming.Lab2.Entities.PersonalComputer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidationModel.ComponentValidator;

public class RAMAndCoolingSystemValidator : IComponentValidator
{
    public CompatibilityResult? Validate(PCModel pcModel)
    {
        return pcModel.RAM.IsCoolingSystemCompatible(pcModel.CoolingSystem);
    }
}