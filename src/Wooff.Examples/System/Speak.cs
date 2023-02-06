using System.Linq;
using System.Threading.Tasks;
using Wooff.ECS;
using Wooff.ECS.Context;
using Wooff.ECS.Entity;
using Wooff.Examples.Components.CoreComponent;

namespace Wooff.Examples.System;

public class Speak : ECS.System.System
{
    public override void Update(float timeScale, IContext<IEntity> data)
    {
        foreach (var speaker in data.Where(
                         x => x.Contains<Speaker>())
                     .Select(x => x.GetFirstNullable<Speaker>()))
            speaker?.Speak();
    }

    public override async Task UpdateParallelAsync(float timeScale, IContext<IEntity> data)
    {
        foreach (var chunk in data.SplitIntoChunks(4))
        {
            await chunk
                .Where(x => x.Contains<Speaker>())
                .Select(x => x.GetFirstNullable<Speaker>())
                .ParallelForEachAsync(x =>
                {
                    x?.Speak();
                    return Task.CompletedTask;
                });
        }
    }
}