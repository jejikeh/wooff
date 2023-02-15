using System.Collections.Generic;
using Wooff.ECS.Components;
using Wooff.ECS.Context;

namespace Wooff.ECS.Entities {
    public interface IEntity : IContext<IComponent<IConfig>, HashSet<IComponent<IConfig>>>, IContextItem
    {
        
    }
}