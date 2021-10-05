#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using VEngine.Inventory;
using InventoryType = VEngine.Inventory.InventoryReference.InventoryType;

namespace VEditor.Items
{
	[CustomPropertyDrawer(typeof(InventoryReference))]
	public class InventoryReferenceDrawer : PropertyDrawer
	{
		private GUIStyle popupStyle;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return 50.0f;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Using BeginProperty / EndProperty on the parent property means that
            // prefab override logic works on the entire property.
            EditorGUI.BeginProperty(position, label, property);

            // Draw label
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            // Don't make child fields be indented
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            // Calculate rects
            SerializedProperty type = property.FindPropertyRelative("_type");
            var typeRect = new Rect(position.x, position.y, position.width, 20);
            var inventoryRect = new Rect(position.x, position.y + typeRect.height, position.width, 20);
            var globalRect = new Rect(position.x, position.y + inventoryRect.height, position.width, 20);

            // Draw fields - passs GUIContent.none to each so they are drawn without labels
            EditorGUI.PropertyField(typeRect, property.FindPropertyRelative("_type"), GUIContent.none);
            if(type.enumValueIndex == 0)
                EditorGUI.PropertyField(inventoryRect, property.FindPropertyRelative("_localInventory"), GUIContent.none);
            else
                EditorGUI.PropertyField(globalRect, property.FindPropertyRelative("_globalInventories"), GUIContent.none);

            position.height += 60;
            // Set indent back to what it was
            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }
}
#endif
