#if UNITY_EDITOR
using VEngine.SO.Variables;
using UnityEditor;
using UnityEngine;

namespace VTest.SO.Variables
{
    [CustomEditor(typeof(Vector3VariableWithOnChangeEvent), editorForChildClasses: true)]
    public class Vector3VariableWithOnChangeEventDrawer : TVariableWithOnChangeEventDrawer<Vector3>
    {
    }
}
#endif