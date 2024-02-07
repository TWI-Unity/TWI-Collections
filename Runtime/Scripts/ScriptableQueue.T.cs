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
        private T[] _collection;
        private Queue<T> _queue;

        #region IScriptableCollection<T>

        public int Count => _queue.Count;

        bool ICollection.IsSynchronized => ((ICollection)_queue).IsSynchronized;

        object ICollection.SyncRoot => ((ICollection)_queue).SyncRoot;

        public void Clear() => _queue.Clear();
        public bool Contains(T item) => _queue.Contains(item);
        void ICollection.CopyTo(Array array, int index) => ((ICollection)_queue).CopyTo(array, index);
        public void CopyTo(T[] array, int arrayIndex) => _queue.CopyTo(array, arrayIndex);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<T> GetEnumerator() => _queue.GetEnumerator();

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            _collection ??= Array.Empty<T>();
            _queue = new(_collection);
            _collection = null;
        }
        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            _queue ??= new();
            _collection = _queue.ToArray();
        }

        public T[] ToArray() => _queue.ToArray();
        public void TrimExcess() => _queue.TrimExcess();

        #endregion
        #region IScriptableQueue<T>

        public T Dequeue() => _queue.Dequeue();
        public void Enqueue(T item) => _queue.Enqueue(item);
        public T Peek() => _queue.Peek();
        public bool TryDequeue(out T result) => _queue.TryDequeue(out result);
        public bool TryPeek(out T result) => _queue.TryPeek(out result);

        #endregion
    }
}