using System;
using Wooff.ECS.Contexts;
using Wooff.ECS.Entities;
using Wooff.Examples.Components;

namespace Wooff.Examples.System;

public class Speak : ECS.Systems.System
{
    public override void UpdateFromEntityQuery(float timeScale, IContextQueryable<IEntity> context)
    {
        var informationAndSpeadyEntities =
            context.ContextWhereQueryable(x => x.ContextContains<Information>() && x.ContextContains<Speedy>());
        foreach (var entity in informationAndSpeadyEntities)
        {
            var information = entity.ContextGet<Information>();
            var speedy = entity.ContextGet<Speedy>();
            Console.WriteLine($"Title: {information?.Title}\n" +
                              $"Description: {information?.Description}\n" +
                              $"Speed: {speedy.Speed}\n\n---------------------\n");
        }
    }
}