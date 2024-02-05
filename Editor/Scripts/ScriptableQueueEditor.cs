namespace TWIEditor.Collections
{
    using TWI.Collections;
    using UnityEditor;

    [CustomEditor(typeof(ScriptableQueue<>), true)]
    public sealed class ScriptableQueueEditor : ScriptableCollectionEditor
    {

    }
}