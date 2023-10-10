public class CustomStack<T>
{
    private List<T> items = new List<T>();

    public void Push(T item)
    {
        items.Add(item);
    }

    public T Pop()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        int lastIndex = items.Count - 1;
        T item = items[lastIndex];
        items.RemoveAt(lastIndex);
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
