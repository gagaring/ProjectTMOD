#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using VEngine.Crafting;

namespace VEditor.Crafting
{
    [CustomEditor(typeof(RecipeGameEvent), editorForChildClasses: true)]
    public class RecipeGameEventDrawer : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            var variable = target as RecipeGameEvent;

            if (GUILayout.Button("Raise"))
            {
				variable.Raise((IRecipe)variable.TestRecipe);
			}
        }
    }
}
#endif