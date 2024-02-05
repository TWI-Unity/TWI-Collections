namespace TWI.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using TWI.Collections.Interfaces;
    using UnityEngine;

    public abstract class ScriptableQueue<T> : ScriptableObject, IScriptableQueue<T>
    {
        [SerializeField]
        private T[] _array;
        private Queue<T> _collection;

        #region IScriptableCollection<T>

        public int Count => _collection.Count;

        bool ICollection.IsSynchronized => ((ICollection)_collection).IsSynchronized;

        object ICollection.SyncRoot => ((ICollection)_collection).SyncRoot;

        public void Clear() => _collection.Clear();
        public bool Contains(T item) => _collection.Contains(item);
        void ICollection.CopyTo(Array array, int index) => ((ICollection)_collection).CopyTo(array, index);
        public void CopyTo(T[] array, int arrayIndex) => _collection.CopyTo(array, arrayIndex);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<T> GetEnumerator() => _collection.GetEnumerator();

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            _array ??= Array.Empty<T>();
            _collection = new(_array);
            _array = null;
        }
        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            _collection ??= new();
            _array = _collection.ToArray();
        }

        public T[] ToArray() => _collection.ToArray();
        public void TrimExcess() => _collection.TrimExcess();

        #endregion
        #region IScriptableQueue<T>

        public T Dequeue() => _collection.Dequeue();
        public void Enqueue(T item) => _collection.Enqueue(item);
        public T Peek() => _collection.Peek();
        public bool TryDequeue(out T result) => _collection.TryDequeue(out result);
        public bool TryPeek(out T result) => _collection.TryPeek(out result);

        #endregion
    }
}