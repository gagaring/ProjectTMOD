#if UNITY_EDITOR
using UnityEditor;
using VEngine.Inventory.GUI.Stash;

namespace VEngine.Inventory
{
    //[CustomEditor(typeof(StashGUIBehaviour))]
    public class StashGUIBehaviourDrawer : InventoryGUIBehaviourDrawer
    {
        SerializedProperty _stashComponents;

        protected override void OnEnable()
        {
            base.OnEnable();
            _stashComponents = serializedObject.FindProperty("_stashComponents");
        }

        protected override void CreatePropertyFields()
        {
            base.CreatePropertyFields();
            EditorGUILayout.LabelField("Split", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(_stashComponents);
        }
    }
}
#endif
