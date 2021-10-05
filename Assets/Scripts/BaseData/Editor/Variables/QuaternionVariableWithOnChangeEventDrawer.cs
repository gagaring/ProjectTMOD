#if UNITY_EDITOR
using VEngine.SO.Variables;
using UnityEditor;
using UnityEngine;

namespace VTest.SO.Variables
{
    [CustomEditor(typeof(QuaternionVariableWithOnChangeEvent), editorForChildClasses: true)]
    public class QuaternionVariableWithOnChangeEventDrawer : TVariableWithOnChangeEventDrawer<Quaternion>
    {
    }
}
#endif