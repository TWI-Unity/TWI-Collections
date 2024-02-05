namespace TWIEditor.Collections
{
    using UnityEditor;
    using UnityEngine.UIElements;

    public abstract class ScriptableCollectionEditor : Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            VisualElement root = new();
            ListView listView = new()
            {
                bindingPath = "_array",
                headerTitle = "Collection",
                name = "scriptable-collection",
                reorderable = true,
                reorderMode = ListViewReorderMode.Animated,
                selectionType = SelectionType.Multiple,
                showAddRemoveFooter = true,
                showAlternatingRowBackgrounds = AlternatingRowBackground.All,
                showBoundCollectionSize = true,
                showBorder = true,
                showFoldoutHeader = true,
                virtualizationMethod = CollectionVirtualizationMethod.DynamicHeight,
            };

            root.Add(listView);
            return root;
        }
    }
}