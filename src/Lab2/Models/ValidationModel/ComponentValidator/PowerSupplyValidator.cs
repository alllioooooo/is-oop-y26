using Itmo.ObjectOrientedProgramming.Lab2.Entities.PersonalComputer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidationModel.ComponentValidator;

public class PowerSupplyValidator : IComponentValidator
{
    public CompatibilityResult? Validate(PCModel pcModel)
    {
        return pcModel.PowerSupply.IsPowerSupplyCompatible(pcModel.CPU, pcModel.RAM, pcModel.GPU, pcModel.SSD, pcModel.HDD, pcModel.WiFiAdapter);
    }
}