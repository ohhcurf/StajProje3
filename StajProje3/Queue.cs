public class CustomQueue<T>
{
    private List<T> items = new List<T>();

    public void Enqueue(T item)
    {
        items.Add(item);
    }

    public T Dequeue()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        T item = items[0];
        items.RemoveAt(0);
        return item;
    }

    public int Count
    {
        get { return items.Count; }
    }
    public void Clear()
    {
        items.Clear();
    }
}
