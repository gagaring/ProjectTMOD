#if UNITY_EDITOR
using VEngine.SO.Variables;
using UnityEditor;
using UnityEngine;

namespace VTest.SO.Variables
{
    [CustomEditor(typeof(GameObjectVariableWithOnChangeEvent), editorForChildClasses: true)]
    public class GameObjectVariableWithOnChangeEventDrawer : TVariableWithOnChangeEventDrawer<GameObject>
    {
    }
}
#endif