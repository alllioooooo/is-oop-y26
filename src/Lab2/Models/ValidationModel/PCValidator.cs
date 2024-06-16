using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PersonalComputer;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ValidationModel.ComponentValidator;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidationModel;

public class PCValidator : IPCValidator
{
    private readonly PCModel _pcModel;
    private readonly List<IComponentValidator> _validators;

    public PCValidator(PCModel pcModel)
    {
        _pcModel = pcModel;
        _validators = new List<IComponentValidator>
        {
            new CoolingSystemAndCPUValidator(),
            new MotherboardAndCPUValidator(),
            new PCCaseAndGPUValidator(),
            new PCCaseAndMotherboardValidator(),
            new PowerSupplyValidator(),
            new RAMAndCoolingSystemValidator(),
            new StorageDeviceValidator(),
        };
    }

    public IReadOnlyList<CompatibilityResult?> ValidateComponents()
    {
        var validationResults = new List<CompatibilityResult?>();

        foreach (IComponentValidator validator in _validators)
        {
            CompatibilityResult? result = validator.Validate(_pcModel);
            validationResults.Add(result);
        }

        return validationResults;
    }
}