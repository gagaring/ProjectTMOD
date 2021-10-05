#if UNITY_EDITOR
using UnityEditor;
using VEngine.Inventory.GUI;

namespace VEngine.Inventory
{
	//[CustomEditor(typeof(InventoryGUIBehaviour))]
	public class InventoryGUIBehaviourDrawer : Editor
    {
        SerializedProperty _inventoryData;
        SerializedProperty _inventoryComponents;

        protected virtual void OnEnable()
        {
            _inventoryData = serializedObject.FindProperty("_inventoryData");
            _inventoryComponents = serializedObject.FindProperty("_inventoryComponents");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            CreatePropertyFields();
            serializedObject.ApplyModifiedProperties();
        }

        protected virtual void CreatePropertyFields()
		{
            EditorGUILayout.PropertyField(_inventoryData);
            EditorGUILayout.PropertyField(_inventoryComponents);
        }
    }
}
#endif
