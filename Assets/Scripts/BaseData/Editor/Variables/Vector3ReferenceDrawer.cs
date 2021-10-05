#if UNITY_EDITOR
using UnityEditor;
using VEngine.SO.Variables;

namespace VTest.SO.Variables
{
    [CustomPropertyDrawer(typeof(Vector3Reference))]
    public class Vector3ReferenceDrawer : ReferenceDrawer
    {
    }
}
#endif
