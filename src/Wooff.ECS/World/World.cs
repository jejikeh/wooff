using System.Threading.Tasks;
using Wooff.ECS.Context;
using Wooff.ECS.Entity;

namespace Wooff.ECS.World
{

    public abstract class World : IWorld
    {
        public IContext<IEntity> EntityContext { get; } = new EntityContext();
        private readonly IUpdateable? _entityContextUpdate;

        protected World()
        {
            _entityContextUpdate = EntityContext as IUpdateable;
        }

        public virtual void Update(float timeScale)
        {
            _entityContextUpdate?.Update(timeScale);
        }

        public async Task UpdateParallelAsync(float timeScale)
        {
            await _entityContextUpdate?.UpdateParallelAsync(timeScale)!;
        }
    }
}