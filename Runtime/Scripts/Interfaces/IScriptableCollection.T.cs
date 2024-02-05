namespace TWI.Collections.Interfaces
{
    using System.Collections.Generic;
    using UnityEngine;

    public interface IScriptableCollection<T> : IScriptableCollection, IReadOnlyCollection<T>
    {
        void CopyTo(T[] array, int arrayIndex);
        T[] ToArray();
    }
}
