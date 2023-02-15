using System.Collections.Generic;
using Wooff.ECS.Context;

namespace Wooff.ECS.Entities 
{
    public class EntityContext : Context<IEntity, List<IEntity>>, IListContext<IEntity> 
    {
        
    }
}