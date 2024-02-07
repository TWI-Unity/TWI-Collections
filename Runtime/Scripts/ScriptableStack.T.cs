namespace TWI.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using TWI.Collections.Interfaces;
    using UnityEngine;

    public abstract class ScriptableStack<T> : ScriptableObject, IScriptableStack<T>
    {
        [SerializeField]
        private T[] _collection;
        private Stack<T> _stack;

        #region IScriptableCollection<T>

        public int Count => _stack.Count;

        bool ICollection.IsSynchronized => ((ICollection)_stack).IsSynchronized;

        object ICollection.SyncRoot => ((ICollection)_stack).SyncRoot;

        public void Clear() => _stack.Clear();
        public bool Contains(T item) => _stack.Contains(item);
        void ICollection.CopyTo(Array array, int index) => ((ICollection)_stack).CopyTo(array, index);
        public void CopyTo(T[] array, int arrayIndex) => _stack.CopyTo(array, arrayIndex);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<T> GetEnumerator() => _stack.GetEnumerator();

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            _collection ??= Array.Empty<T>();
            _stack = new(_collection);
            _collection = null;
        }
        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            _stack ??= new();
            _collection = _stack.ToArray();
        }

        public T[] ToArray() => _stack.ToArray();
        public void TrimExcess() => _stack.TrimExcess();

        #endregion
        #region IScriptableCollection<T>

        public T Peek() => _stack.Peek();
        public T Pop() => _stack.Pop();
        public void Push(T item) => _stack.Push(item);
        public bool TryPeek(out T result) => _stack.TryPeek(out result);
        public bool TryPop(out T result) => _stack.TryPop(out result);

        #endregion
    }
}