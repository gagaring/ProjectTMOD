#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using VEngine.Items;

namespace VEditor.Items
{
    [CustomEditor(typeof(ItemGameEvent), editorForChildClasses: true)]
    public class ItemGameEventDrawer : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            var variable = target as ItemGameEvent;

            if (GUILayout.Button("Raise"))
            {
                variable.Raise(variable.TestItem);
            }
        }
    }
}
#endif