namespace Wooff.ECS.Context;

public interface IContext<T> : ICollection<T>
{
    public T1 Add<T1>() where T1 :  T, new();
    public T1 Add<T1>(params object[] data) where T1 :  T, IInitable, new();
    public T1 Add<T1, T2>(params T2[] data) where T1 :  T, IInitable<T2>, new();

    public T1 Add<T1>(Func<object[], T1> action,params object[] data) where T1 :  T, IInitable, new();
    public void Remove<T1>() where T1 : T;
    public T1 Get<T1>() where T1 : class, T;
    public List<T1?> GetAll<T1>() where T1 : class, T, new();

    public List<List<T>> SplitIntoChunks(int chunkSize);
}