#if UNITY_EDITOR
using UnityEditor;
using VEngine.Items;

namespace VEditor.Items
{
	//[CustomEditor(typeof(Item))]
	public class ItemDrawer : Editor
	{
        SerializedProperty _details;

        SerializedProperty _stackable;
        SerializedProperty _stackCount;

        void OnEnable()
        {
            _stackable = serializedObject.FindProperty("_stackable");
            _stackCount = serializedObject.FindProperty("_stackCount");
            _details = serializedObject.FindProperty("_details");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(_details);
            EditorGUILayout.PropertyField(_stackable);
            if (_stackable.boolValue)
                EditorGUILayout.PropertyField(_stackCount);
            serializedObject.ApplyModifiedProperties();
        }
	}
}
#endif
