using Wooff.ECS.Context;
using Wooff.ECS.Entity;

namespace Wooff.ECS.World;

public interface IWorld : IUpdateable
{
    IContext<IEntity> EntityContext { get; }
}