using Wooff.ECS.Context;
using Wooff.ECS.Entities;

namespace Wooff.ECS.Components
{
    public interface IComponent<T> : IContextItem, IConfigurable<T> where T : IConfig
    {
        public IEntity Handler { get; } 
    }
}