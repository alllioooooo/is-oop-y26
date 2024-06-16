using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComponentRepositoryService
{
    private readonly Dictionary<string, object> _components = new(ComponentRepository.GetDefaultComponents());

    public void RegisterComponent(string componentName, object component)
    {
        _components[componentName] = component;
    }

    public object? GetComponent(string componentName)
    {
        _components.TryGetValue(componentName, out object? component);
        return component;
    }
}