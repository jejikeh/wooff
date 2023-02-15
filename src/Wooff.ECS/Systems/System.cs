using System.Collections.Generic;
using Wooff.ECS.Context;
using Wooff.ECS.Entities;

namespace Wooff.ECS.Systems 
{
    public abstract class System : ISystem
    {
        public abstract void Process(float timeScale, IContext<IEntity, List<IEntity>> data);
    }
}