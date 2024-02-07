namespace TWI.Collections
{
    using System.Collections;
    using UnityEngine;

    public interface IScriptableCollection : ICollection, IEnumerable, ISerializationCallbackReceiver
    {
        void Clear();
        void TrimExcess();
    }
}
