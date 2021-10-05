#if UNITY_EDITOR
using VEngine.SO.Variables;
using UnityEditor;
using UnityEngine;

namespace VTest.SO.Variables
{
    public class TVariableWithOnChangeEventDrawer<T> : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            var variable = target as TVariableWithOnChangeEvent<T>;
            if (GUILayout.Button("Raise"))
			{
                variable.OnChangedEvent.Raise(variable.Value);
            }
        }
    }
}
#endif