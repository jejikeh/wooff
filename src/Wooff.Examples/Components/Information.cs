using Wooff.ECS.Components;

namespace Wooff.Examples.Components
{
    public class Information : IComponent
    {
        public string Title { get; init; }
        public string Description { get; init; }
    }
}