using System;
using Wooff.ECS.Contexts;
using Wooff.ECS.Entities;

namespace Wooff.ECS.Systems 
{
    public interface ISystem : IProcessable<IContext<IEntity>>
    {
        public void UpdateFromEntityQuery(float timeScale, IContextQueryable<IEntity> context);
        public void UpdateFromTypeQuery(float timeScale, IContextQueryable<Type> context);
    }
}