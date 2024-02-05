namespace TWI.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using TWI.Collections.Interfaces;
    using UnityEngine;

    public abstract class ScriptableList<T> : ScriptableObject, IScriptableList<T>
    {
        [SerializeField]
        private T[] _array;
        private List<T> _collection;

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
        }
        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            _collection ??= new();
            _array = _collection.ToArray();
        }

        public T[] ToArray() => _collection.ToArray();
        public void TrimExcess() => _collection.TrimExcess();

        #endregion
        #region List<T>

        public int Capacity
        {
            get => _collection.Capacity;
            set => _collection.Capacity = value;
        }

        bool IList.IsFixedSize => ((IList)_collection).IsFixedSize;
        bool ICollection<T>.IsReadOnly => ((ICollection<T>)_collection).IsReadOnly;
        bool IList.IsReadOnly => ((IList)_collection).IsReadOnly;

        object IList.this[int index]
        {
            get => ((IList)_collection)[index];
            set => ((IList)_collection)[index] = value;
        }
        public T this[int index]
        {
            get => _collection[index];
            set => _collection[index] = value;
        }

        int IList.Add(object value) => ((IList)_collection).Add(value);
        public void Add(T item) => _collection.Add(item);
        public void AddRange(IEnumerable<T> collection) => _collection.AddRange(collection);
        public ReadOnlyCollection<T> AsReadOnly() => _collection.AsReadOnly();

        public int BinarySearch(T item) => _collection.BinarySearch(item);
        public int BinarySearch(T item, IComparer<T> comparer) => _collection.BinarySearch(item, comparer);
        public int BinarySearch(int index, int count, T item, IComparer<T> comparer) => _collection.BinarySearch(index, count, item, comparer);

        bool IList.Contains(object value) => ((IList)_collection).Contains(value);
        public List<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter) => _collection.ConvertAll(converter);
        public void CopyTo(T[] array) => _collection.CopyTo(array);
        public void CopyTo(int index, T[] array, int arrayIndex, int count) => _collection.CopyTo(index, array, arrayIndex, count);

        public bool Exists(Predicate<T> match) => _collection.Exists(match);

        public T Find(Predicate<T> match) => _collection.Find(match);
        public List<T> FindAll(Predicate<T> match) => _collection.FindAll(match);
        public int FindIndex(Predicate<T> match) => _collection.FindIndex(match);
        public int FindIndex(int startIndex, Predicate<T> match) => _collection.FindIndex(startIndex, match);
        public int FindIndex(int startIndex, int count, Predicate<T> match) => _collection.FindIndex(startIndex, count, match);
        public T FindLast(Predicate<T> match) => _collection.FindLast(match);
        public int FindLastIndex(Predicate<T> match) => _collection.FindLastIndex(match);
        public int FindLastIndex(int startIndex, Predicate<T> match) => _collection.FindLastIndex(startIndex, match);
        public int FindLastIndex(int startIndex, int count, Predicate<T> match) => _collection.FindLastIndex(startIndex, count, match);
        public void ForEach(Action<T> action) => _collection.ForEach(action);

        public List<T> GetRange(int index, int count) => _collection.GetRange(index, count);

        int IList.IndexOf(object value) => ((IList)_collection).IndexOf(value);
        public int IndexOf(T item) => _collection.IndexOf(item);
        public int IndexOf(T item, int index) => _collection.IndexOf(item, index);
        public int IndexOf(T item, int index, int count) => _collection.IndexOf(item, index, count);
        void IList.Insert(int index, object value) => ((IList)_collection).Insert(index, value);
        public void Insert(int index, T item) => _collection.Insert(index, item);
        public void InsertRange(int index, IEnumerable<T> collection) => _collection.InsertRange(index, collection);

        public int LastIndexOf(T item) => _collection.LastIndexOf(item);
        public int LastIndexOf(T item, int index) => _collection.LastIndexOf(item, index);
        public int LastIndexOf(T item, int index, int count) => _collection.LastIndexOf(item, index, count);

        void IList.Remove(object value) => ((IList)_collection).Remove(value);
        public bool Remove(T item) => _collection.Remove(item);
        public int RemoveAll(Predicate<T> match) => _collection.RemoveAll(match);
        public void RemoveAt(int index) => _collection.RemoveAt(index);
        public void RemoveRange(int index, int count) => _collection.RemoveRange(index, count);
        public void Reverse() => _collection.Reverse();
        public void Reverse(int index, int count) => _collection.Reverse(index, count);

        public void Sort() => _collection.Sort();
        public void Sort(IComparer<T> comparer) => _collection.Sort(comparer);
        public void Sort(Comparison<T> comparison) => _collection.Sort(comparison);
        public void Sort(int index, int count, IComparer<T> comparer) => _collection.Sort(index, count, comparer);

        public bool TrueForAll(Predicate<T> match) => _collection.TrueForAll(match);

        #endregion
    }
}
