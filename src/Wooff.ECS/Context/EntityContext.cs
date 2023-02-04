using Wooff.ECS.Entity;

namespace Wooff.ECS.Context;

public class EntityContext : Context<IEntity>, IUpdateable
{
    public void Update(float timeScale)
    {
        foreach (var entity in this)
            entity.Update(timeScale);
    }

    public async Task UpdateParallelAsync(float timeScale)
    {
        await Parallel.ForEachAsync(SplitIntoChunks(4), async (chunk, token)  =>
        {
            await chunk.ParallelForEachAsync(async entity => await entity.UpdateParallelAsync(timeScale));
            Console.WriteLine("-----------------");
        });
    }
}