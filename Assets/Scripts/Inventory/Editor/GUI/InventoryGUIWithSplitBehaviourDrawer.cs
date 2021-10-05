#if UNITY_EDITOR
using UnityEditor;
using VEngine.Inventory.GUI;

namespace VEngine.Inventory
{
    //[CustomEditor(typeof(InventoryGUIWithSplitBehaviour))]
    public class InventoryGUIWithSplitBehaviourDrawer : InventoryGUIBehaviourDrawer
    {
        SerializedProperty _invSplitData;
        protected override void OnEnable()
        {
            base.OnEnable();
            _invSplitData = serializedObject.FindProperty("_invSplitData");
        }

        protected override void CreatePropertyFields()
		{
			base.CreatePropertyFields();
            EditorGUILayout.LabelField("Split", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(_invSplitData);
        }
	}
}
#endif
