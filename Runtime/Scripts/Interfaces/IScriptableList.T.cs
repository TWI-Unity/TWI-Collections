namespace TWI.Collections
{
    using System.Collections.Generic;

    public interface IScriptableList<T> : IScriptableCollection<T>, IScriptableList, IList<T>, IReadOnlyList<T>
    {

    }
}