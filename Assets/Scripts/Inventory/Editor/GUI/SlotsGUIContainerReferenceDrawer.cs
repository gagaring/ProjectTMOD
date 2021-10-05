#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using VEngine.Inventory.GUI;

namespace VEditor.Inventory.GUI
{
    [CustomPropertyDrawer(typeof(SlotsGUIContainerReference))]
    class SlotsGUIContainerReferenceDrawer : PropertyDrawer
    {
		private GUIStyle popupStyle;

        private readonly string[] popupOptions =
            { "Variable", "Behaviours"};

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (popupStyle == null)
            {
				popupStyle = new GUIStyle(UnityEngine.GUI.skin.GetStyle("PaneOptions"));
				popupStyle.imagePosition = ImagePosition.ImageOnly;
            }
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            SerializedProperty useBehaviours = property.FindPropertyRelative("_useBehaviours");

            Rect buttonRect = new Rect(position);
            buttonRect.yMin += popupStyle.margin.top;
            buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
            position.xMin = buttonRect.xMax;

            int result = EditorGUI.Popup(buttonRect, useBehaviours.boolValue ? 1 : 0, popupOptions, popupStyle);

            useBehaviours.boolValue = result == 1;

            if (useBehaviours.boolValue)
                EditorGUI.PropertyField(position, property.FindPropertyRelative("_behaviours"), GUIContent.none);
            else
                EditorGUI.PropertyField(position, property.FindPropertyRelative("_variable"), GUIContent.none);

            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }
}
#endif