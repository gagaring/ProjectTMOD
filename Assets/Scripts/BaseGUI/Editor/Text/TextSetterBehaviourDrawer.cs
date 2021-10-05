#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using VEngine.GUI.Text;

namespace VTest.SO.Events
{
    [CustomEditor(typeof(TextSetterBehaviour), editorForChildClasses: true)]
    public class TextSetterBehaviourDrawer : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            UnityEngine.GUI.enabled = !Application.isPlaying;

            TextSetterBehaviour fontSetter = target as TextSetterBehaviour;
            if (GUILayout.Button("Refresh"))
            {
                fontSetter.RefreshFont();
                fontSetter.RefreshText();
            }
        }
    }
}
#endif