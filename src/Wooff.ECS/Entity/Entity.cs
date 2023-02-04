using Wooff.ECS.Component;
using Wooff.ECS.Context;

namespace Wooff.ECS.Entity;

public abstract class Entity : Context<IComponent>, IEntity<IComponent>
{
    public new IComponent Add(IComponent item)
    {
        if (Contains(item))
            throw new ArgumentException($"Component {item.GetType().FullName} is already attached to entity {GetType().FullName}");

        base.Add(item);
        return item;
    }

    public new T1 Add<T1>(params object[] data) where T1 : IComponent, IInitable, new()
    {
        var item = IInitable.Initialize<T1>(data) as IComponent;
        if (item is not T1 parsedComponent || Contains<T1>())
            throw new ArgumentException($"Component {item.GetType().FullName} is already attached to entity {GetType().FullName}");
        
        Add(parsedComponent);
        return parsedComponent;
    }

    public new T1 Add<T1, T2>(params T2[] data) where T1 : IComponent, IInitable<T2>, new()
    {
        var item = IInitable<T2>.Initialize<T1>(data) as IComponent;
        if (item is not T1 parsedComponent || Contains<T1>())
            throw new ArgumentException($"Component {item.GetType().FullName} is already attached to entity {GetType().FullName}");
        
        Add(parsedComponent);
        return parsedComponent;
    }
    
    // TODO: add new overrides for ContextAdd method

    public virtual void Update(float timeScale) { }
    
    public virtual Task UpdateParallelAsync(float timeScale)
    { 
        return Task.Run(() => Update(timeScale));
    }
    
    public virtual IInitable Init(params object[] data)
    {
        return this;
    }

    public IInitable<IComponent> Init(params IComponent[] data)
    {
        foreach (var component in data)
            Add(component);

        return this;
    }
}

public abstract class Entity<T> : Entity, IEntity<T>
{
    public abstract IInitable<T> Init(params T[] data);
}