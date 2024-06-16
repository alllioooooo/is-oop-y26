using Itmo.ObjectOrientedProgramming.Lab2.Entities.PersonalComputer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidationModel.ComponentValidator;

public class StorageDeviceValidator : IComponentValidator
{
    public CompatibilityResult? Validate(PCModel pcModel)
    {
        if (pcModel.SSD == null && pcModel.HDD == null)
        {
            return new NotCompatible("A computer must have either an SSD or HDD.");
        }

        return new Compatible("Compatible");
    }
}