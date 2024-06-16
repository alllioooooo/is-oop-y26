using Itmo.ObjectOrientedProgramming.Lab2.Entities.PersonalComputer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidationModel.ComponentValidator;

public interface IComponentValidator
{
    public CompatibilityResult? Validate(PCModel pcModel);
}