namespace TWI.Collections
{
    public interface IScriptableQueue<T> : IScriptableCollection<T>, IScriptableQueue
    {
        T Dequeue();
        void Enqueue(T item);
        T Peek();
        bool TryDequeue(out T result);
        bool TryPeek(out T result);
    }
}