using Wooff.ECS;

namespace Wooff.Examples.Components;

public class InformationData : IConfig
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}