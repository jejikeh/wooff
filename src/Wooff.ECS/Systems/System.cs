using System;
using Wooff.ECS.Contexts;
using Wooff.ECS.Entities;

namespace Wooff.ECS.Systems
{
    public abstract class System : ISystem
    {
        public void Process(float timeScale, IContext<IEntity> data)
        {
            if(data is IContextQueryable<IEntity> contextQueryableEntity)
                UpdateFromEntityQuery(timeScale, contextQueryableEntity);
            if(data is IContextQueryable<Type> contextQueryableType)
                UpdateFromTypeQuery(timeScale, contextQueryableType);
        }

        public virtual void UpdateFromEntityQuery(float timeScale, IContextQueryable<IEntity> context)
        {
        }

        public virtual void UpdateFromTypeQuery(float timeScale, IContextQueryable<Type> context)
        {
        }
    }
}