#if UNITY_EDITOR
using VEngine.SO.Variables;
using UnityEditor;

namespace VTest.SO.Variables
{
    [CustomEditor(typeof(BoolVariableWithOnChangeEvent), editorForChildClasses: true)]
    public class BoolVariableWithOnChangeEventDrawer : TVariableWithOnChangeEventDrawer<bool>
    {
    }
}
#endif