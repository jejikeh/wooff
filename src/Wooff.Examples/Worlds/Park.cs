using System.Collections.Generic;
using Wooff.ECS;
using Wooff.ECS.Contexts;
using Wooff.ECS.Entities;
using Wooff.ECS.Systems;
using Wooff.ECS.Worlds;
using Wooff.Examples.System;

namespace Wooff.Examples.Worlds
{
    public class Park : IWorld
    {
        public IContext<IEntity, List<IEntity>> EntityContext { get; } = new EntityContext();
        public IContext<ISystem, HashSet<ISystem>> SystemContext { get; } = new SystemContext();

        public Park()
        {
            SystemContext.ContextAdd(new Speak());
        }

        public void Update(float timeScale)
        {
            (SystemContext as IProcessable<IContext<IEntity, List<IEntity>>>)?.Process(timeScale, EntityContext);
        }
    }
}