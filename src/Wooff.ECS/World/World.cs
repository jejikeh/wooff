using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
        
        public async Task Save()
        {
            await File.WriteAllTextAsync(
                "t.json",
                JsonConvert.SerializeObject(this,
                    new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, Formatting = Formatting.Indented}));
        }
        
        public static async Task<T> Load<T>() where T : World
        {
            return JsonConvert.DeserializeObject<T>(await File.ReadAllTextAsync("t.json"), 
                    new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
        }
    }
}