using System.Collections;

namespace Wooff.ECS.Context;

public class Context<T> : IContext<T>
{
    private List<T> _items = new List<T>();

    public IEnumerator<T> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(T item)
    {
        _items.Add(item);
    }

    public void Clear()
    {
        _items.Clear();
    }

    public bool Contains(T item)
    {
        return _items.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        _items.CopyTo(array, arrayIndex);
    }

    public bool Remove(T item)
    {
        return _items.Remove(item);
    }

    public int Count => _items.Count;
    public bool IsReadOnly => false;
    
    public List<T> this[Type type]
    {
        get
        {
            var itemList = _items.Where(entity => entity?.GetType() == type);
            if (itemList is null)
                throw new NullReferenceException($"{type.FullName} item does not exist");

            return itemList.ToList();
        }
    }

    public T1 Add<T1>() where T1 : T, new()
    {
        var item = new T1();
        Add(item);
        return item;
    }

    public T1 Add<T1>(params object[] data) where T1 : T, IInitable, new()
    {
        var item = IInitable.Initialize<T1>(data);
        Add(item);
        return item;
    }

    public T1 Add<T1, T2>(params T2[] data) where T1 : T, IInitable<T2>, new()
    {
        var item = IInitable<T2>.Initialize<T1>(data);
        Add(item);
        return item;
    }

    public T1 Add<T1>(Func<object, T1> action, params object[] data) where T1 : T, IInitable, new()
    {
        var item = IInitable.Initialize(action, data);
        Add(item);
        return item;
    }

    public void Remove<T1>() where T1 : T
    {
        var itemIndex = _items.FindIndex(temp => temp?.GetType() == typeof(T1));
        if(itemIndex > 0)
            _items.RemoveAt(itemIndex);
    }

    public T1 Get<T1>() where T1 : class, T
    {
        if (this[typeof(T1)][0] is not T1 item)
            throw new NullReferenceException($"{typeof(T1).FullName} class is not relate to {typeof(T).FullName} class");

        return item;
    }
}