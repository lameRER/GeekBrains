namespace Task_4;

public class SafeList<T>
{
    private readonly List<T> _list = new();
    private readonly object _lockObject = new();
    
    public void Add(T item)
    {
        lock (_lockObject)
        {
            _list.Add(item);        
        }
    }

    public void Remove(T item)
    {
        lock (_lockObject)
        {
            _list.Remove(item);
        }
    }
}
