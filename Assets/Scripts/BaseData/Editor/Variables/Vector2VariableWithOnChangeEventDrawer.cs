#if UNITY_EDITOR
using VEngine.SO.Variables;
using UnityEditor;
using UnityEngine;

namespace VTest.SO.Variables
{
    [CustomEditor(typeof(Vector2VariableWithOnChangeEvent), editorForChildClasses: true)]
    public class Vector2VariableWithOnChangeEventDrawer : TVariableWithOnChangeEventDrawer<Vector2>
    {
    }
}
#endif