using Wooff.ECS.Component;
using Wooff.ECS.Context;

namespace Wooff.ECS.Entity;

public abstract class Entity : Context<IComponent>, IEntity
{
    public virtual void Update(float timeScale) { }
    
    public virtual Task UpdateParallelAsync(float timeScale)
    { 
        return Task.Run(() => Update(timeScale));
    }

    public IInitable<IComponent> Init(params IComponent[] data)
    {
        foreach (var component in data)
            Add(component);

        return this;
    }

    public IInitable Init(params object[] data)
    {
        foreach (var temp in data)
            if(temp is IComponent component)
                Add(component);

        return this;
    }
}