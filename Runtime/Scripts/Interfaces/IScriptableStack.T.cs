namespace TWI.Collections
{
    public interface IScriptableStack<T> : IScriptableCollection<T>, IScriptableStack
    {
        T Peek();
        T Pop();
        void Push(T item);
        bool TryPeek(out T result);
        bool TryPop(out T result);
    }
}
