using Wooff.ECS.Entity;

namespace Wooff.ECS.Context;

public class EntityContext : Context<IEntity>, IUpdateable
{
    public void Update(float timeScale)
    {
        foreach (var entity in this)
            entity.Update(timeScale);
    }
}