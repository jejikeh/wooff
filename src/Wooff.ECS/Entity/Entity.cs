using Wooff.ECS.Component;
using Wooff.ECS.Context;

namespace Wooff.ECS.Entity;

public abstract class Entity : Context<IComponent>, IEntity
{
    public void Update(float timeScale)
    {
        foreach (var component in this)
            component.Update(timeScale);
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