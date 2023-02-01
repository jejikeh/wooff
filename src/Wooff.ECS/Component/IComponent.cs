namespace Wooff.ECS.Component;

public interface IComponent: IUpdateable, IInitable
{
    
}

public interface IComponent<T> : IComponent, IInitable<T>
{
    
}