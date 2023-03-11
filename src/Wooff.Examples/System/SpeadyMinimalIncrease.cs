using Wooff.ECS.Contexts;
using Wooff.ECS.Entities;
using Wooff.Examples.Components;

namespace Wooff.Examples.System;

public class SpeadyMinimalIncrease : ECS.Systems.System
{
    public override void UpdateFromEntityQuery(float timeScale, IContextQueryable<IEntity> context)
    {
        var negativeSeedEntity =
            context.ContextWhereQueryable(
                x => x.ContextContains<Speedy>() && x.ContextGet<Speedy>()?.Speed < 0);
        foreach (var entity in negativeSeedEntity)
        {
            var speedy = entity.ContextGet<Speedy>();
            speedy.Speed += 0.01f;
        }
    }
}