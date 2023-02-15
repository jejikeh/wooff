using System.Collections.Generic;
using Wooff.ECS.Context;
using Wooff.ECS.Entities;

namespace Wooff.ECS.Worlds
{
    public interface IWorld
    {
        public IContext<IEntity, List<IEntity>> EntityContext { get; }
        public IContext<ISystem, HashSet<ISystem>> SystemContext { get; }
    }
}
