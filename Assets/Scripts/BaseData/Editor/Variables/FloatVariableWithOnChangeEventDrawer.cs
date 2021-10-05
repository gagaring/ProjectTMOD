#if UNITY_EDITOR
using VEngine.SO.Variables;
using UnityEditor;

namespace VTest.SO.Variables
{
    [CustomEditor(typeof(FloatVariableWithOnChangeEvent), editorForChildClasses: true)]
    public class FloatVariableWithOnChangeEventDrawer : TVariableWithOnChangeEventDrawer<float>
    {
    }
}
#endif