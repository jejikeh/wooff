using System.Collections.Generic;

namespace Wooff.ECS.Context 
{
    public interface IHashContext<T> : IContext<T, HashSet<T>> where T : IContextItem
    {
    }
}