using System.Collections.Generic;

namespace Wooff.ECS.Context 
{
    public interface IListContext<T> : IContext<T, List<T>> where T : IContextItem
    {
        
    }
}