using Wooff.ECS.Contexts;
using Wooff.ECS.Worlds;

namespace Wooff.Examples.Worlds
{
    public class Park : IWorld
    {
        public EntityContext EntityContext { get; } = new EntityContext();
        public SystemContext SystemContext { get; } = new SystemContext();
    }
}