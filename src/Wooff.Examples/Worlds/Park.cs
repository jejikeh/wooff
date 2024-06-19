using System.Collections.Generic;
using Wooff.ECS;
using Wooff.ECS.Contexts;
using Wooff.ECS.Entities;
using Wooff.ECS.Systems;
using Wooff.ECS.Worlds;
using Wooff.Examples.System;

namespace Wooff.Examples.Worlds
{
    public class Park : IWorld<IExampleEntity, IExampleSystem>
    {
        public IContext<IExampleEntity, List<IExampleEntity>> EntityContext { get; } = new EntityContext<IExampleEntity>();
        public IContext<IExampleSystem, HashSet<IExampleSystem>> SystemContext { get; } = new SystemContext<IExampleSystem, IExampleEntity>();

        public Park()
        {
            SystemContext.ContextAdd(new Speak());
        }

        public void Update(float timeScale)
        {
            (SystemContext as IProcessable<IContext<IExampleEntity, List<IExampleEntity>>>)?.Process(timeScale, EntityContext);
        }
    }
}