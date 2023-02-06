using System.Threading.Tasks;

namespace Wooff.ECS
{

    public interface ISaveable<T>
    {
        public T Data { get; }
        public Task Save();
        public bool Load(T save);
    }
}