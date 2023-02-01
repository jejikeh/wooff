using Wooff.ECS;
using Wooff.ECS.Context;
using Wooff.ECS.Entity;
using Wooff.ECS.World;

namespace Wooff.Examples.Worlds;

public class Park : IWorld
{
    public IContext<IEntity> EntityContext { get; } = new EntityContext();
    private readonly IUpdateable? _entityContextUpdate;

    public Park()
    {
        _entityContextUpdate = EntityContext as IUpdateable;
    }
    
    public void Update(float timeScale)
    {
        _entityContextUpdate?.Update(timeScale);
    }
}