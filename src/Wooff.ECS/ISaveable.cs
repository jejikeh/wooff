namespace Wooff.ECS;

public interface ISaveable<T>
{
    public void Save();
    public bool Load(T save);
}