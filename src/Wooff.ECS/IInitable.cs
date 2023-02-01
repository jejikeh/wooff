namespace Wooff.ECS;

public interface IInitable
{
    public IInitable Init(params object[] data);
    
    public static T Initialize<T>(params object[] data) where T : IInitable, new()
    {
        var item = new T();
        item.Init(data);
        return item;
    }

    public static T Initialize<T>(Func<object[], T> action, params object[] data) where T : IInitable, new()
    {
        var item = action.Invoke(data);
        return item;
    }
}

// ReSharper disable once TypeParameterCanBeVariant
public interface IInitable<T> : IInitable
{
    public IInitable<T> Init(params T[] data);

    public static T1 Initialize<T1>(params T[] data) where T1 : IInitable<T>, new()
    {
        var item = new T1();
        item.Init(data);
        return item;
    }
}