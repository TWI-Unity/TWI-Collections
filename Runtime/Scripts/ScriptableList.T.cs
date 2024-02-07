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
        private T[] _collection;
        private List<T> _list;

        #region IScriptableCollection<T>

        public int Count => _list.Count;

        bool ICollection.IsSynchronized => ((ICollection)_list).IsSynchronized;

        object ICollection.SyncRoot => ((ICollection)_list).SyncRoot;

        public void Clear() => _list.Clear();
        public bool Contains(T item) => _list.Contains(item);
        void ICollection.CopyTo(Array array, int index) => ((ICollection)_list).CopyTo(array, index);
        public void CopyTo(T[] array, int arrayIndex) => _list.CopyTo(array, arrayIndex);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            _collection ??= Array.Empty<T>();
            _list = new(_collection);
        }
        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            _list ??= new();
            _collection = _list.ToArray();
        }

        public T[] ToArray() => _list.ToArray();
        public void TrimExcess() => _list.TrimExcess();

        #endregion
        #region List<T>

        public int Capacity
        {
            get => _list.Capacity;
            set => _list.Capacity = value;
        }

        bool IList.IsFixedSize => ((IList)_list).IsFixedSize;
        bool ICollection<T>.IsReadOnly => ((ICollection<T>)_list).IsReadOnly;
        bool IList.IsReadOnly => ((IList)_list).IsReadOnly;

        object IList.this[int index]
        {
            get => ((IList)_list)[index];
            set => ((IList)_list)[index] = value;
        }
        public T this[int index]
        {
            get => _list[index];
            set => _list[index] = value;
        }

        int IList.Add(object value) => ((IList)_list).Add(value);
        public void Add(T item) => _list.Add(item);
        public void AddRange(IEnumerable<T> collection) => _list.AddRange(collection);
        public ReadOnlyCollection<T> AsReadOnly() => _list.AsReadOnly();

        public int BinarySearch(T item) => _list.BinarySearch(item);
        public int BinarySearch(T item, IComparer<T> comparer) => _list.BinarySearch(item, comparer);
        public int BinarySearch(int index, int count, T item, IComparer<T> comparer) => _list.BinarySearch(index, count, item, comparer);

        bool IList.Contains(object value) => ((IList)_list).Contains(value);
        public List<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter) => _list.ConvertAll(converter);
        public void CopyTo(T[] array) => _list.CopyTo(array);
        public void CopyTo(int index, T[] array, int arrayIndex, int count) => _list.CopyTo(index, array, arrayIndex, count);

        public bool Exists(Predicate<T> match) => _list.Exists(match);

        public T Find(Predicate<T> match) => _list.Find(match);
        public List<T> FindAll(Predicate<T> match) => _list.FindAll(match);
        public int FindIndex(Predicate<T> match) => _list.FindIndex(match);
        public int FindIndex(int startIndex, Predicate<T> match) => _list.FindIndex(startIndex, match);
        public int FindIndex(int startIndex, int count, Predicate<T> match) => _list.FindIndex(startIndex, count, match);
        public T FindLast(Predicate<T> match) => _list.FindLast(match);
        public int FindLastIndex(Predicate<T> match) => _list.FindLastIndex(match);
        public int FindLastIndex(int startIndex, Predicate<T> match) => _list.FindLastIndex(startIndex, match);
        public int FindLastIndex(int startIndex, int count, Predicate<T> match) => _list.FindLastIndex(startIndex, count, match);
        public void ForEach(Action<T> action) => _list.ForEach(action);

        public List<T> GetRange(int index, int count) => _list.GetRange(index, count);

        int IList.IndexOf(object value) => ((IList)_list).IndexOf(value);
        public int IndexOf(T item) => _list.IndexOf(item);
        public int IndexOf(T item, int index) => _list.IndexOf(item, index);
        public int IndexOf(T item, int index, int count) => _list.IndexOf(item, index, count);
        void IList.Insert(int index, object value) => ((IList)_list).Insert(index, value);
        public void Insert(int index, T item) => _list.Insert(index, item);
        public void InsertRange(int index, IEnumerable<T> collection) => _list.InsertRange(index, collection);

        public int LastIndexOf(T item) => _list.LastIndexOf(item);
        public int LastIndexOf(T item, int index) => _list.LastIndexOf(item, index);
        public int LastIndexOf(T item, int index, int count) => _list.LastIndexOf(item, index, count);

        void IList.Remove(object value) => ((IList)_list).Remove(value);
        public bool Remove(T item) => _list.Remove(item);
        public int RemoveAll(Predicate<T> match) => _list.RemoveAll(match);
        public void RemoveAt(int index) => _list.RemoveAt(index);
        public void RemoveRange(int index, int count) => _list.RemoveRange(index, count);
        public void Reverse() => _list.Reverse();
        public void Reverse(int index, int count) => _list.Reverse(index, count);

        public void Sort() => _list.Sort();
        public void Sort(IComparer<T> comparer) => _list.Sort(comparer);
        public void Sort(Comparison<T> comparison) => _list.Sort(comparison);
        public void Sort(int index, int count, IComparer<T> comparer) => _list.Sort(index, count, comparer);

        public bool TrueForAll(Predicate<T> match) => _list.TrueForAll(match);

        #endregion
    }
}
