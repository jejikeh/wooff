using Wooff.ECS.Components;
using Wooff.ECS.Entities;

namespace Wooff.ECS
{
    public abstract class Component<T> : IComponent<T> where T : IConfig
    {
        public T Config { get; private set; }
        public IEntity Handler { get; private set; }

        public abstract int GetId();

        public Component(T data, IEntity handler)
        {
            Config = data;
            Handler = handler;
        }
    }
}