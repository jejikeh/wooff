using System.Collections.Generic;
using Wooff.ECS.Components;
using Wooff.ECS.Context;

namespace Wooff.ECS.Entities 
{
    public class Entity : Context<IComponent<IConfig>, HashSet<IComponent<IConfig>>>, IHashContext<IComponent<IConfig>>, IEntity
    {
    }
}