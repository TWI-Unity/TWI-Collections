namespace TWI.Collections
{
    using System.Collections.Generic;

    public interface IScriptableCollection<T> : IScriptableCollection, IReadOnlyCollection<T>
    {
        void CopyTo(T[] array, int arrayIndex);
        T[] ToArray();
    }
}
