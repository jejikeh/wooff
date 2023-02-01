using Wooff.ECS.Component;
using Wooff.ECS.Context;

namespace Wooff.ECS.Entity;

public interface IEntity : IContext<IComponent>, IUpdateable, IInitable<IComponent>
{
}