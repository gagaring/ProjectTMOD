#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using VEngine.Inventory;
using VEngine.Items;

namespace VEditor.Inventory
{
	[CustomPropertyDrawer(typeof(ItemSlot))]
	public class ItemSlotDrawer : PropertyDrawer
	{

        /// <summary>
        /// Options to display in the popup to select constant or variable.
        /// </summary>
        private readonly string[] popupOptions =
            { "Use Constant", "Use Variable" };

        /// <summary> Cached style to use to draw the popup button. </summary>
        private GUIStyle popupStyle;

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return 45.0f;
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
            SerializedProperty itemProp = property.FindPropertyRelative("_item");
            var itemRect = new Rect(position.x, position.y - 2, position.width, 20);
            var amountRect = new Rect(position.x, position.y + itemRect.height, position.width, 20);

            var item = itemProp.objectReferenceValue as Item;

            EditorGUI.PropertyField(itemRect, itemProp, GUIContent.none);
            if (item != null && InventoryItemComponent.FindOn(item).IsStackable)
            {
                amountRect.width = 50;
                EditorGUI.LabelField(amountRect, "Amount: ");
                amountRect.x += 50;
                amountRect.y += 2;
                amountRect.width = 40;
                EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("_amount"), GUIContent.none);
            }
            else
            {
                var amountProp = property.FindPropertyRelative("_amount");
                var amountInt = amountProp.intValue;
                EditorGUI.LabelField(amountRect, $"Not stackable ({amountInt})");
                if (amountInt != 1)
                    amountProp.intValue = 1;
            }

            // Set indent back to what it was
            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }
}
#endif