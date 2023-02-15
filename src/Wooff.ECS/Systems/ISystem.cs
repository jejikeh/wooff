using System.Collections.Generic;
using Wooff.ECS.Context;
using Wooff.ECS.Entities;

namespace Wooff.ECS 
{
    public interface ISystem : IProcessable<IContext<IEntity, List<IEntity>>>, IContextItem
    {

    }
}